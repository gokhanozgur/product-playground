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

namespace ProductPlayground.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : BaseHandler, IRequestHandler<UpdateProductCommandRequest, Unit>
    {
        public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ProductRules productRules) : base(mapper, unitOfWork, httpContextAccessor)
        {

        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.DeletedDate.HasValue);

            var map = mapper.Map<Product, UpdateProductCommandRequest>(request);
            map.UpdatedDate = DateTime.Now;

            var productCategories = await unitOfWork.GetReadRepository<ProductCategory>().GetAllAsync(x => x.ProductId == product.Id);

            await unitOfWork.GetWriteRepository<ProductCategory>().HardDeleteRangeAsync(productCategories);

            foreach (var categoryId in request.CategoryIds)
            {
                await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                {
                    CategoryId = categoryId,
                    ProductId = product.Id,
                });
            }

            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(map);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
