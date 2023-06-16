using AE.Application.CommonModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Application.Modules.ShipModule.Commands.CommandModels
{
    public class DeleteShipCommand : IRequest<BaseResponse>
    {
        public DeleteShipCommand(Guid id) 
        { 
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
