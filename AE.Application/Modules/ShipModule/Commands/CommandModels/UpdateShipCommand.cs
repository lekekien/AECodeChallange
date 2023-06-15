using AE.Application.CommonModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Application.Modules.ShipModule.Commands.CommandModels
{
    public class UpdateShipCommand : IRequest<BaseResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public double Velocity { get; set; }
    }
}
