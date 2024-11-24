using AutoMapper;
using BookStore.BL.Users.Entity;
using BookStore.BL.Users.Exception;
using BookStore.Repository;
using BookStore.DataAccess.Entities;

namespace BookStore.BL.Users.Provider;

public class UsersProvider : IUsersProvider
{
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;
    
    public UsersProvider(IRepository<User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public IEnumerable<UserModel> GetUsers()
    {
        var users = _userRepository.GetAll();
        if (users == null)
        {
            throw new UserNotFoundException("User not found.");
        }

        return _mapper.Map<IEnumerable<UserModel>>(users);
    }

    public UserModel GetUserInfo(int id)
    {
        var user = _userRepository.GetById(id);
        if (user == null)
        {
            throw new UserNotFoundException("User not found.");
        }

        return _mapper.Map<UserModel>(user);
    }
}