
namespace DealDunia.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public int RootId { get; set; }
        public int ParentId { get; set; }
        public int Level { get; set; }
    }

    public class CategoryValues
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
