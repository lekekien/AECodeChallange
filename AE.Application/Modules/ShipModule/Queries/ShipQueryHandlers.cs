using AE.Application.Modules.ShipModule.Queries.Models;
using AE.Application.Modules.ShipModule.Queries.ResponseModels;
using AE.Application.Repository;
using AE.Data.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Application.Modules.ShipModule.Queries
{
    public class ShipQueryHandlers : IRequestHandler<GetAllShipQuery, List<ShipResponseModel>>
    {
        private IRepository<Ship> _shipRepository;
        private IMapper _mapper;
        public ShipQueryHandlers(IRepository<Ship> shipRepository, IMapper mapper) 
        { 
            _shipRepository = shipRepository;
            _mapper = mapper;
        }
        public async Task<List<ShipResponseModel>> Handle(GetAllShipQuery request, CancellationToken cancellationToken)
        {
            var allShip = await _shipRepository.GetAll()
                                               .OrderBy(x => x.CreateTime)
                                               .ToListAsync(cancellationToken);
            return _mapper.Map<List<ShipResponseModel>>(allShip);
        }
    }
}
