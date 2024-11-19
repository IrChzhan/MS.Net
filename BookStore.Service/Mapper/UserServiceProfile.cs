using AutoMapper;
using BookStore.BL.Users.Entity;
using BookStore.Service.Controllers.Entities;
using BookStore.Service.Controllers.Users.Entities;

namespace BookStore.Service.Mapper;

public class UserServiceProfile : Profile
{
    public UserServiceProfile()
    {
        CreateMap<FilterUser, UserFilter>();
        CreateMap<RegisterUserRequest, CreateUserModel>();
    }
}