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
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256);

            Faker faker = new("en");

            List<Brand> brands = new List<Brand>();

            for (int i = 1; i <= 3; i++)
            {
                Brand brand = new Brand
                {
                    Id = i,
                    Name = faker.Commerce.Department(),
                    CreaetedDate = DateTime.Now,
                };
                brands.Add(brand);
            }

            builder.HasData(brands);
        }
    }
}
