using AE.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Data.Entities
{
    public class Ship : BaseAuditableEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Longtitude { get; set; }
        [Required]
        public double Latitude { get; set; }

        public double Velocity { get; set; }
    }
}
