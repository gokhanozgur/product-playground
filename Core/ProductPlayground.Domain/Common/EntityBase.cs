using System;
namespace ProductPlayground.Domain.Common
{
	public class EntityBase:IEntityBase
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}

