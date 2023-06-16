using AE.Application.Modules.ShipModule.Queries.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Application.Modules.ShipModule.Queries.Models
{
    public class GetAllShipQuery : IRequest<List<ShipResponseModel>>
    {
    }
}
