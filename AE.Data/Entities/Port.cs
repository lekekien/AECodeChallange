using AE.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Data.Entities
{
    public class Port : BaseEntity
    {
        public string Name { get; set; }   
        public double Longtitude { get; set; }
        public double Lattitude { get; set; }
    }
}
