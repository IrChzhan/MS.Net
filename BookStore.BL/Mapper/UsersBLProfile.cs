using AutoMapper;
using BookStore.BL.Users.Entity;
using BookStore.DataAccess.Entities;

namespace BookStore.BL.Mapper
{
    public class UsersBLProfile : Profile
    {
        public UsersBLProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(a => a.Id, b => b.MapFrom(src => src.Id))
                .ForMember(a => a.Role, b => b.MapFrom(src => src.Role))
                .ForMember(a => a.Name, b => b.MapFrom(src => src.Name))
                .ForMember(a => a.PasswordHash, b => b.MapFrom(src => src.PasswordHash))
                .ForMember(a=>a.Login,b=>b.MapFrom(src=>src.Login))
                .ReverseMap();

            CreateMap<CreateUserModel, User>()
                .ForMember(a => a.Id, b => b.Ignore())
                .ForMember(a => a.Role, b => b.MapFrom(src => src.Role))
                .ForMember(a => a.PasswordHash, b => b.MapFrom(src => src.PasswordHash))
                .ForMember(a => a.Login, b => b.MapFrom(src => src.Login));

        }
    }
}
