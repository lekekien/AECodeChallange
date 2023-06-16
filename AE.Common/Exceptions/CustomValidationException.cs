using AE.Common.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Common.Exceptions
{
    public class CustomValidationException : Exception
    {
        public IEnumerable<Error> Errors { get; }

        public CustomValidationException(string msg, IEnumerable<Error> errors) : base(msg)
        {
            Errors = errors;
        }
    }
}
