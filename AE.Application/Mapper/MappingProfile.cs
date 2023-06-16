using AE.Application.Modules.PortModule.Queries.ResponseModels;
using AE.Application.Modules.ShipModule.Commands.CommandModels;
using AE.Application.Modules.ShipModule.Queries.ResponseModels;
using AE.Data.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateShipCommand, Ship>();
            CreateMap<UpdateShipCommand, Ship>();

            CreateMap<Ship, ShipResponseModel>();
            CreateMap<Port, ClosestPortModel>();
        }
    }
}
