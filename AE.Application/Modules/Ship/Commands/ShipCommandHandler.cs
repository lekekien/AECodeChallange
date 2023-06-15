using AE.Application.CommonModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Application.Modules.Ship.Commands
{
    public class ShipCommandHandler : IRequestHandler<CreateShipCommand, BaseResponse>
    {
        public Task<BaseResponse> Handle(CreateShipCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
