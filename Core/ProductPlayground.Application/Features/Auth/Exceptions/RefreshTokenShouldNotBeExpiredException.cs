using ProductPlayground.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPlayground.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpiredException : BaseExceptions
    {
        public RefreshTokenShouldNotBeExpiredException() : base("User session ended. Please login.") { }
    }
}
