using AE.Application.Mapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.UnitTesting.Mapping
{
    public static class MapperConfig
    {
        public static IMapper InitFromBaseProject()
        {
            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            return mapper;
        }
    }
}
