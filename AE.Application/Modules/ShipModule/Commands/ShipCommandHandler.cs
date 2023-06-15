using AE.Application.CommonModels;
using AE.Application.Modules.ShipModule.Commands.CommandModels;
using AE.Application.Repository;
using AE.Data.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Application.Modules.ShipModule.Commands
{
    public class ShipCommandHandler : IRequestHandler<CreateShipCommand, BaseResponse>, IRequestHandler<UpdateShipCommand,BaseResponse>
    {
        private IRepository<Ship> _shipRepository;
        private IMapper _mapper;

        public ShipCommandHandler(IRepository<Ship> shipRepository, IMapper mapper)
        {
            _shipRepository = shipRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(CreateShipCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var shipEntity = _mapper.Map<Ship>(request);
                shipEntity.Id = Guid.NewGuid();
                await _shipRepository.AddAsync(shipEntity, cancellationToken);
                return new BaseResponse
                {
                    Message = "Success",
                    Data = shipEntity
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseResponse> Handle(UpdateShipCommand request, CancellationToken cancellationToken)
        {
            var existingData =  _shipRepository.FindOne(ship => ship.Id == request.Id);
            if (existingData == null)
            {
                throw new Exception("Ship is not existing !");
            }
            try
            {
                _mapper.Map(request, existingData);
                await _shipRepository.UpdateAsync(existingData, cancellationToken);
                return new BaseResponse
                {
                    Message = "Success",
                    Data = existingData
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
