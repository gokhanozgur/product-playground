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
            Category category1 = new Category { 
                Id = 1,
                Name = "Electronic",
                Priorty = 1,
                ParentId = 0,
                CreaetedDate = DateTime.Now
            };

            Category category2 = new Category
            {
                Id = 2,
                Name = "Moda",
                Priorty = 2,
                ParentId = 0,
                CreaetedDate = DateTime.Now
            };

            Category subCategory1 = new Category
            {
                Id = 3,
                Name = "Computer",
                Priorty = 1,
                ParentId = 1,
                CreaetedDate = DateTime.Now
            };

            Category subCategory2 = new Category
            {
                Id = 4,
                Name = "Dress",
                Priorty = 2,
                ParentId = 2,
                CreaetedDate = DateTime.Now
            };

            Faker faker = new("en");

            List<Category> categories = new List<Category>();

            for (int i = 5; i <= 10; i++)
            {
                Category category = new Category
                {
                    Id = i,
                    Name = faker.Commerce.Department(),
                    Priorty = new Random().Next(1,11),
                    ParentId = new Random().Next(1, 5),
                    CreaetedDate = DateTime.Now,
                };
                categories.Add(category);
            }

            builder.HasData(category1, category2, subCategory1, subCategory2, categories);
        }
    }
}
