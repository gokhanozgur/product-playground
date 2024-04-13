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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            List<Category> categories = new List<Category>();

            Category category1 = new Category { 
                Id = 1,
                Name = "Electronic",
                Priority = 1,
                ParentId = 0,
                CreatedDate = DateTime.Now
            };

            categories.Add(category1);

            Category category2 = new Category
            {
                Id = 2,
                Name = "Moda",
                Priority = 2,
                ParentId = 0,
                CreatedDate = DateTime.Now
            };

            categories.Add(category2);

            Category subCategory1 = new Category
            {
                Id = 3,
                Name = "Computer",
                Priority = 1,
                ParentId = 1,
                CreatedDate = DateTime.Now
            };

            categories.Add(subCategory1);

            Category subCategory2 = new Category
            {
                Id = 4,
                Name = "Dress",
                Priority = 2,
                ParentId = 2,
                CreatedDate = DateTime.Now
            };

            categories.Add(subCategory2);

            Faker faker = new("en");

            for (int i = 5; i <= 10; i++)
            {
                Category category = new Category
                {
                    Id = i,
                    Name = faker.Commerce.Department(),
                    Priority = new Random().Next(1,11),
                    ParentId = new Random().Next(1, 5),
                    CreatedDate = DateTime.Now,
                };
                categories.Add(category);
            }

            builder.HasData(categories);
        }
    }
}
