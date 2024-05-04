using ProductPlayground.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPlayground.Application.Features.Products.Exceptions
{
    public class ProductTitleMustNotBeSameException : BaseExceptions
    {
        // TODO The exception message should be translatable...
        public ProductTitleMustNotBeSameException() : base("Product title already exist.") { }
    }
}
