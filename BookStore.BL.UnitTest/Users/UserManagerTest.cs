using System.Linq.Expressions;
using BookStore.BL.UnitTest.Mapper;
using BookStore.BL.Users.Entity;
using BookStore.BL.Users.Manager;
using BookStore.DataAccess.Entities;
using BookStore.Repository;
using Moq;

namespace BookStore.BL.UnitTest.Users;

public class UserManagerTests
{
    [Test]
    public void TestCreateUser_Success()
    {
        Mock<IRepository<User>> repositoryMock = new Mock<IRepository<User>>();
        repositoryMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<User, bool>>>()))
            .Returns(new List<User>().AsQueryable());
        repositoryMock.Setup(x => x.Save(It.IsAny<User>()))
            .Returns((User x) =>
            {
                x.Id = 1;
                x.CreationTime=DateTime.Now;
                x.ModificationTime=DateTime.Now;
                x.ExternalId=Guid.NewGuid();
                return x;
            });

        var mapper = MapperHelper.Mapper;
        var userManager = new UsersManager(repositoryMock.Object, mapper);
        var createUserModel = new CreateUserModel()
        {
            Name = "Chzhan Irina"
        };
        var userModel = userManager.CreateUser(createUserModel);
        userModel.Should().NotBeNull();
        userModel.Id.Should().Be(1);
        userModel.Name.Should().Be(createUserModel.Name);
    }
    
    [Test]
    public void TestUpdateUser_Success()
    {
        var userId = 1;
        var initialExternalId = Guid.NewGuid();
        var initialCreationTime = DateTime.Now.AddDays(-1); 
        var initialModificationTime = DateTime.Now.AddDays(-1);

        var initialUser = new User
        {
            Id = userId,
            ExternalId = initialExternalId,
            CreationTime = initialCreationTime,
            ModificationTime = initialModificationTime,
            Name = "Old Name"
        };

        var updatedName = "Updated Name";
        var updateUser = new User
        {
            Id = userId,
            Name = updatedName
        };

        var updateUserModel = new UpdateUserModel 
        {
            Id = userId,
            Name = updatedName
        };

        var mockRepository = new Mock<IRepository<User>>();
        mockRepository.Setup(x => x.GetById(userId)).Returns(initialUser);
        mockRepository.Setup(x => x.Save(It.IsAny<User>())).Returns((User user) =>
        {
            user.ModificationTime = DateTime.Now; 
            return user;
        });
        mockRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<User, bool>>>()))
            .Returns(new List<User> { initialUser }.AsQueryable());

        var mapper = MapperHelper.Mapper;
        var userManager = new UsersManager(mockRepository.Object, mapper);

        var updatedUser = userManager.UpdateUser(updateUserModel);
        updatedUser.Should().NotBeNull();
        updatedUser.Id.Should().Be(userId);
        updatedUser.Name.Should().Be(updatedName);
    }
}