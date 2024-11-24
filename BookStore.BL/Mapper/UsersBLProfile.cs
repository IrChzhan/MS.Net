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
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(x => x.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(x => x.CreationTime, opt => opt.MapFrom(src => src.CreationTime))
                .ForMember(x => x.ModificationTime, opt => opt.MapFrom(src => src.ModificationTime));


            CreateMap<User, CreateUserModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(x => x.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash));


            CreateMap<User, UpdateUserModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(x => x.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash));
        }
    }
}
