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

    public UserModel CreateUser(CreateUserModel createUserModel)
    {
        var user = _mapper.Map<User>(createUserModel);
        user = _usersRepository.Save(user);
        return _mapper.Map<UserModel>(user);
    }
    
    public UserModel UpdateUser(UpdateUserModel updateUserModel)
    {
        var user = _mapper.Map<User>(updateUserModel);
        user = _usersRepository.Save(user);
        return _mapper.Map<UserModel>(user);
    }
    
    public void DeleteUser(int id)
    {
        var user = _usersRepository.GetById(id);
        if (user == null)
        {
            throw new UserNotFoundException("User not found.");
        }
            
        _usersRepository.Delete(user);
    }
    
}