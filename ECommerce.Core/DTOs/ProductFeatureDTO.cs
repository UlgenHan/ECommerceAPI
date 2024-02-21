
namespace ECommerce.Core.DTOs
{
    public class ProductFeatureDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public int ProductId { get; set; }
    }
}
