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

    public IEnumerable<UserModel> GetUsers(FilterUser filter = null)
    {

        var users = _userRepository.GetAll();
        if (!string.IsNullOrEmpty(filter.NamePart))
        {
            users = users.Where(u => u.Name.Contains(filter.NamePart));
        }
        
        if (!string.IsNullOrEmpty(filter.PhoneNumberPart))
        {
            users = users.Where(u => u.PhoneNumber.Contains(filter.PhoneNumberPart));
        }

        return users.Select(u => _mapper.Map<UserModel>(u)).ToList();
    }

    public UserModel GetUserInfo(int id)
    {
        var entity = _userRepository.GetById(id);
        if (entity == null)
        {
            throw new UserNotFound("User not found");
        }

        return _mapper.Map<UserModel>(entity);
    }
}