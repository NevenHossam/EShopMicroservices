using System;
namespace Catalog.API.Models
{
	public class Product
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = default!;
		public List<string> Category { get; set; } = new();
        public string Desc { get; set; } = default!;
        public string ImgFile { get; set; } = default!;
        public decimal Price { get; set; }
    }
}

