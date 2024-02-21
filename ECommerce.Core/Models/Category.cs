namespace ECommerce.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int ParentCategoryId { get; set; }

        public Category ParentCategory { get; set; }

        public List<Category> SubCategories { get; set;}
    }
}
