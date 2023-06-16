using AE.Application.Modules.PortModule.Queries.Models;
using AE.Application.Modules.PortModule.Queries.ResponseModels;
using AE.Application.Repository;
using AE.Data.Entities;
using AutoMapper;
using GeoCoordinatePortable;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Application.Modules.PortModule.Queries
{
    public class PortQueryHandler : IRequestHandler<GetClosestPortQuery,ClosestPortModel>
    {
        private IMapper _mapper;
        private IRepository<Port> _portRepositoty;
        private IRepository<Ship> _shipRepository;
        public PortQueryHandler(IRepository<Port> portRepositoty, IRepository<Ship> shipRepository, IMapper mapper)
        {
            _portRepositoty = portRepositoty;
            _shipRepository = shipRepository;
            _mapper = mapper;
        }

        public async Task<ClosestPortModel> Handle(GetClosestPortQuery request, CancellationToken cancellationToken)
        {
            var ship = _shipRepository.FindOne(x => x.Id == request.ShipId);
            
            if(ship == null)
            {
                throw new Exception("Ship is not existing!");
            }
            var allPort = await _portRepositoty.GetAll().ToListAsync(cancellationToken);
            if (!allPort.Any())
            {
                throw new Exception("No port found in system!");
            }
            var shipPoint = new GeoCoordinate(ship.Latitude, ship.Longtitude);
            double minDistance = double.MaxValue;
            var closestPort = new Port();
            foreach (var port in allPort)
            {
                var portPoit = new GeoCoordinate(port.Lattitude, port.Longtitude);
                var distanceFromShipToPort = shipPoint.GetDistanceTo(portPoit);
                if(distanceFromShipToPort < minDistance)
                {
                    minDistance = distanceFromShipToPort;
                    closestPort = port;
                }
            }
            var closestPortModel = _mapper.Map<ClosestPortModel>(closestPort);
            var estimateTimeinHours = minDistance / ship.Velocity;
            closestPortModel.DistanceToClosestPort = $"{Math.Round(minDistance / 1000, 3)} km";
            closestPortModel.EstimateArrivalTime = DateTime.UtcNow.AddHours(estimateTimeinHours);
            return closestPortModel;
        }
    }
}
