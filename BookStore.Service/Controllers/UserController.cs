using AutoMapper;
using BookStore.BL.Users.Entity;
using BookStore.BL.Users.Manager;
using BookStore.BL.Users.Provider;
using BookStore.Service.Controllers.Users.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUsersManager _usersManager;

    private readonly IUsersProvider _usersProvider;

    private readonly IMapper _mapper;

    public UserController(IUsersManager usersManager, IUsersProvider usersProvider, IMapper mapper)
    {
        _usersManager = usersManager;
        _usersProvider = usersProvider;
        _mapper = mapper;
    }
    
    [HttpPost]
    [Route("reg")]
    public IActionResult RegisterUser([FromBody] RegisterUserRequest request)
    {
        try
        {
            var createUserModel = _mapper.Map<CreateUserModel>(request);
            var userModel = _usersManager.CreateUser(createUserModel);
            return Ok(userModel);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error.");
        }
    }
    
    [HttpGet]
    [Route("getAll")]
    public IActionResult GetAllUsers()
    {
        try
        {
            var users = _usersProvider.GetUsers();
            return Ok(new ListResponse()
            {
                Users = users.Select(u => _mapper.Map<UserModel>(u)).ToList()
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error.");
        }
    }
    
    [HttpPut]
    [Route("update")]
    public IActionResult UpdateUserInfo([FromBody] UpdateUserModel request)
    {
        try
        {
            var userModel = _usersManager.UpdateUser(request);
            return Ok(userModel);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error.");
        }
    }
    
    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteUser(int id)
    {
        try
        {
            _usersManager.DeleteUser(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error.");
        }
    }
}