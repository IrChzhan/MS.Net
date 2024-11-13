using AutoMapper;
using BookStore.BL.Users.Entity;
using BookStore.BL.Users.Exception;
using BookStore.DataAccess.Entities;
using BookStore.Repository;

namespace BookStore.BL.Users.Manager;

public class UsersManager : IUsersManager
{
    private readonly IRepository<User> _usersRepository;
    private readonly IMapper _mapper;

    public UsersManager(IRepository<User> usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public UserModel CreateUser(CreateUserModel createModel)
    {
        var entity = _mapper.Map<User>(createModel);
        entity = _usersRepository.Save(entity);
        return _mapper.Map<UserModel>(entity);
    }
    
    public void DeleteUser(int id)
    {
        try
        {
            var entity = _usersRepository.GetById(id);
            _usersRepository.Delete(entity);
        }
        catch (System.Exception e)
        {
            throw new UserNotFound(e.Message);
        }
    }
    
}