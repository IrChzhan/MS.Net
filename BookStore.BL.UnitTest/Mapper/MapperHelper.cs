using BookStore.Service.IoC;
using AutoMapper;
using BookStore.BL.Mapper;

namespace BookStore.BL.UnitTest.Mapper;

public static class MapperHelper
{
    static MapperHelper()
    {
        var config = new MapperConfig(x => x.AddProfile(typeof(UsersBLProfile)));
        Mapper = new AutoMapper.Mapper(config);
    }
    
    public static IMapper Mapper { get;  }
}