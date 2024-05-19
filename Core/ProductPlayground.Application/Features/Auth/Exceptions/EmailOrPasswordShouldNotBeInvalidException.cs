using ProductPlayground.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPlayground.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldNotBeInvalidException : BaseExceptions
    {
        // TODO The exception message should be translatable...
        public EmailOrPasswordShouldNotBeInvalidException() : base("Invalid user credentials.") { }
    }
}
