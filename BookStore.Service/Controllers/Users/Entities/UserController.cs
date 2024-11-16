using AutoMapper;
using BookStore.BL.Users.Entity;
using BookStore.BL.Users.Manager;
using BookStore.BL.Users.Provider;
using BookStore.Service.Controllers.Users.Entities;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;
using BookStore.Service.Validator;

namespace BookStore.Service.Controllers.Users.Entities;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUsersManager _usersManager;
    private readonly IUsersProvider _usersProvider;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public UserController(IUsersManager usersManager, IUsersProvider usersProvider, IMapper mapper, ILogger logger)
    {
        _usersManager = usersManager;
        _usersProvider = usersProvider;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpPost]
    public IActionResult ReguisterUser([FromBody] RegisterUserRequest request)
    {
        var validation = new RegisterUserRequestValidator().Validate(request);
        if (validation.IsValid)
        {
            var createUserModel = _mapper.Map<CreateUserModel>(request);
            var userModel = _usersManager.CreateUser(createUserModel);
            return Ok(new ListResponse()
            {
                Users = [userModel]
            });
        }
        _logger.Error(validation.ToString());
        return BadRequest(validation.ToString());
    }
    
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _usersProvider.GetUsers();
        return Ok(new ListResponse()
        {
            Users = users.ToList()
        });
    }
    
    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredUsers([FromQuery] UserFilter filter)
    {
        var userFilterModel = _mapper.Map<UserFilter>(filter);
        var users = _usersProvider.GetUsers(userFilterModel);
        return Ok(new ListResponse()
        {
            Users = users.ToList()
        });
    }
}