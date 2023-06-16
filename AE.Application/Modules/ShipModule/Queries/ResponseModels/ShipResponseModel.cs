using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Application.Modules.ShipModule.Queries.ResponseModels
{
    public class ShipResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
        public double Velocity { get; set; }
    }
}
