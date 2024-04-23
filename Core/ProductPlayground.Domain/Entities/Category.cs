using System;
using ProductPlayground.Domain.Common;

namespace ProductPlayground.Domain.Entities
{
	public class Category : EntityBase
	{
		public Category()
		{
		}

		public Category(int parentId, string name, int priorty)
		{
			ParentId = parentId;
			Name = name;
			Priority = priorty;
		}

		public int ParentId { get; set; }
		public string Name { get; set; }
		public int Priority { get; set; }

		public ICollection<Detail> Details { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }

    }
}

