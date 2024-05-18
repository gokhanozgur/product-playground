using MediatR;
using Microsoft.AspNetCore.Http;
using ProductPlayground.Application.Bases;
using ProductPlayground.Application.Features.Products.Rules;
using ProductPlayground.Application.Interfaces.AutoMapper;
using ProductPlayground.Application.Interfaces.UnitOfWork;
using ProductPlayground.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPlayground.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : BaseHandler, IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly ProductRules productRules;

        public CreateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ProductRules productRules) : base(mapper, unitOfWork, httpContextAccessor) {
            this.productRules = productRules;
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();

            // It doesn't make sense but i'm just trying something
            await productRules.ProductTitleMustNotBeSame(products, request.Title);

            Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);

            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);

            if (await unitOfWork.SaveAsync() > 0)
            {
                foreach (var categorId in request.CategoryIds)
                {
                    await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categorId
                    });
                }
                await unitOfWork.SaveAsync();
            }

            return Unit.Value;
        }
    }
}
