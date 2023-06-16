using AE.Application.CommonModels;
using AE.Application.Modules.ShipModule.Commands.CommandModels;
using AE.Application.Modules.ShipModule.Commands.Validators;
using AE.Application.Repository;
using AE.Common.Extentions;
using AE.Data.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Application.Modules.ShipModule.Commands
{
    public class ShipCommandHandler : IRequestHandler<CreateShipCommand, BaseResponse>
                                    , IRequestHandler<UpdateShipCommand,BaseResponse>
                                    , IRequestHandler<DeleteShipCommand,BaseResponse>
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
            await new CreateShipCommandValidator().ValidateAndThrowExceptionAsync(request, cancellationToken);
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

        public async Task<BaseResponse> Handle(DeleteShipCommand request, CancellationToken cancellationToken)
        {
            var shipExist = _shipRepository.FindOne(x => x.Id == request.Id);
            if(shipExist == null)
            {
                throw new Exception("Ship is not existing !");
            }
            await _shipRepository.Delete(shipExist, cancellationToken);
            return new BaseResponse { Message = "Success" };
        }
    }
}
