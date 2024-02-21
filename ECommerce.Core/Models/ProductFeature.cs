﻿
namespace ECommerce.Core.Models
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
