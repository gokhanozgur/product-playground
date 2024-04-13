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
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Faker faker = new("en");

            List<Detail> details = new List<Detail>();

            for (int i = 1; i <= 10; i++)
            {
                Detail detail = new Detail
                {
                    Id = i,
                    Title = faker.Lorem.Sentence(1),
                    Description = faker.Lorem.Sentence(1),
                    CategoryId = new Random().Next(1,5),
                    CreatedDate = DateTime.Now,
                };
                details.Add(detail);
            }

            builder.HasData(details);
        }
    }
}
