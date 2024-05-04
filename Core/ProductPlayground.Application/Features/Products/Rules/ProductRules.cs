using ProductPlayground.Application.Bases;
using ProductPlayground.Application.Features.Products.Exceptions;
using ProductPlayground.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPlayground.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(IList<Product> products, string productTitle) 
        {
            if (products.Any(x => x.Title == productTitle)) throw new ProductTitleMustNotBeSameException ();
            return Task.CompletedTask;
        }
    }
}
