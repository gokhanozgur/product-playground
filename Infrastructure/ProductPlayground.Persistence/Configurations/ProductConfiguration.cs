using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductPlayground.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPlayground.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Faker faker = new("en");

            List<Product> products = new List<Product>();

            for (int i = 1; i <= 10; i++)
            {
                Product product = new Product
                {
                    Id = i,
                    Title = faker.Lorem.Sentence(1),
                    Description = faker.Lorem.Sentence(1),
                    BrandId = new Random().Next(1, 4),
                    Price = faker.Finance.Amount(100, 2000),
                    Discount = faker.Finance.Amount(10, 50),
                    CreatedDate = DateTime.Now,
                };
                products.Add(product);
            }

            builder.HasData(products);
        }
    }
}
