using AE.Application.Modules.PortModule.Queries.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Application.Modules.PortModule.Queries.Models
{
    public class GetClosestPortQuery : IRequest<ClosestPortModel>
    {
        public GetClosestPortQuery(Guid shipId) 
        { 
            ShipId = shipId;
        }
        public Guid ShipId { get; set; }
    }
}
