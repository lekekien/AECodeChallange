using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Application.Modules.PortModule.Queries.ResponseModels
{
    public class ClosestPortModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Longtitude { get; set; }
        public double Lattitude { get; set; }

        public DateTime EstimateArrivalTime { get; set; }
        public string DistanceToClosestPort { get; set; }
    }
}
