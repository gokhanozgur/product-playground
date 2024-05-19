using ProductPlayground.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPlayground.Application.Features.Auth.Exceptions
{
    public class EmailAddressShouldBeValidException : BaseExceptions
    {
        // TODO The exception message should be translatable...
        public EmailAddressShouldBeValidException() : base("User not found.") { }
    }
}
