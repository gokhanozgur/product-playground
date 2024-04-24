﻿using System;
using ProductPlayground.Domain.Common;

namespace ProductPlayground.Domain.Entities
{
	public class Product : EntityBase
	{
		public Product()
		{
		}

        public Product(string title, string description, int brandId, decimal price, decimal discount)
        {
            Title = title;
            Description = description;
            BrandId = brandId;
            Price = price;
            Discount = discount;
        }

        public string Title { get; set; }
		public string Description { get; set; }
		//public string ImagePath { get; set; }
		public int BrandId { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }

		public Brand Brand { get; set; }
		public ICollection<ProductCategory> ProductCategories { get; set; }
	}
}

