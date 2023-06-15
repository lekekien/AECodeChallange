using AE.Application.CommonModels;
using AE.Application.Modules.Ship.Commands.CommandModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Application.Modules.Ship.Commands
{
    public class ShipCommandHandler : IRequestHandler<CreateShipCommand, BaseResponse>, IRequestHandler<UpdateShipCommand,BaseResponse>
    {
        public ShipCommandHandler()
        {

        }
        public Task<BaseResponse> Handle(CreateShipCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> Handle(UpdateShipCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
