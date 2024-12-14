using AutoMapper;
using BookStore.BL.Users.Entity;
using BookStore.BL.Users.Exception;
using BookStore.BL.Users.Provider;
using BookStore.DataAccess.Entities;
using BookStore.Repository;
using Moq;
using NUnit.Framework;
using FluentAssertions;


namespace BookStore.BL.UnitTest.Users;

public class UserProviderTests
{
    private readonly IMapper _mapper;

    public UserProviderTests()
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
        _mapper = config.CreateMapper();
    }

    [Test]
    public void GetUsers_ExistingUsers_ReturnsUsers()
    {
        // Arrange
        var users = new List<User>
        {
            new User { Id = 1, Name = "User 1" },
            new User { Id = 2, Name = "User 2" }
        };
        var mockUserRepository = new Mock<IRepository<User>>();
        mockUserRepository.Setup(repo => repo.GetAll()).Returns(users.AsQueryable());

        var userProvider = new UsersProvider(mockUserRepository.Object, _mapper);

        // Act
        var allUsers = userProvider.GetUsers().ToList();

        // Assert
        allUsers.Should().NotBeNullOrEmpty();
        allUsers.Count.Should().Be(2);
        allUsers[0].Name.Should().Be("User 1");
        allUsers[1].Name.Should().Be("User 2");
    }

    [Test]
    public void GetUsers_NoUsers_ThrowsUserNotFoundException()
    {
        // Arrange
        var mockUserRepository = new Mock<IRepository<User>>();
        mockUserRepository.Setup(repo => repo.GetAll()).Returns(Enumerable.Empty<User>().AsQueryable());

        var userProvider = new UsersProvider(mockUserRepository.Object, _mapper);

        // Act & Assert
        Assert.Throws<UserNotFoundException>(() => userProvider.GetUsers().ToList());

    }

    [Test]
    public void GetUserInfo_ExistingUser_ReturnsUserInfo()
    {
        // Arrange
        var userId = 1;
        var expectedUser = new User { Id = userId, Name = "Test User" };
        var mockUserRepository = new Mock<IRepository<User>>();
        mockUserRepository.Setup(repo => repo.GetById(userId)).Returns(expectedUser);

        var userProvider = new UsersProvider(mockUserRepository.Object, _mapper);

        // Act
        var actualUser = userProvider.GetUserInfo(userId);

        // Assert
        actualUser.Should().NotBeNull();
        actualUser.Id.Should().Be(userId);
        actualUser.Name.Should().Be("Test User");
    }


    [Test]
    public void GetUserInfo_NonExistingUser_ThrowsUserNotFoundException()
    {
        // Arrange
        var userId = 999;
        var mockUserRepository = new Mock<IRepository<User>>();
        mockUserRepository.Setup(repo => repo.GetById(userId)).Returns((User)null);

        var userProvider = new UsersProvider(mockUserRepository.Object, _mapper);

        // Act & Assert
        Assert.Throws<UserNotFoundException>(() => userProvider.GetUserInfo(userId));
    }
}