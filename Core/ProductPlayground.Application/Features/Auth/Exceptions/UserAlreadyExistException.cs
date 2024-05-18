using ProductPlayground.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPlayground.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException : BaseExceptions
    {
        // TODO The exception message should be translatable...
        public UserAlreadyExistException() : base("User already exist.") { }
    }
}
