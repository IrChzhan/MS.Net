using AutoMapper;
using BookStore.BL.Users.Entity;
using BookStore.DataAccess.Entities;
using BookStore.Service.Controllers.Users.Entities;

namespace BookStore.BL.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<User, CreateUserModel>();
            CreateMap<User, UpdateUserModel>();
            CreateMap<RegisterUserRequest, CreateUserModel>();
            CreateMap<CreateUserModel, User>();
            CreateMap<UpdateUserModel, User>();
            CreateMap<UserModel, User>();
        }
    }
}