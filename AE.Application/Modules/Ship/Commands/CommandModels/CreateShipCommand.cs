using AE.Application.CommonModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Application.Modules.Ship.Commands
{
    public class CreateShipCommand : IRequest<BaseResponse>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Longtitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Velocity { get; set; }
    }
}
