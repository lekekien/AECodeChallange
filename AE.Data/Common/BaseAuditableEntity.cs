using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Data.Common
{
    public abstract class BaseAuditableEntity : BaseEntity
    {
        public string CreateUser { get; set; }
        public DateTime CreateTime { get; set; }
        public string? UpdateUser { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
