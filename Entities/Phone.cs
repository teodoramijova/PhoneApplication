
namespace Entities
{
    public class Phone : Base
    {
        public string Code { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }
        public Category Category { get; set; }
        public Type Type { get; set; }
    }
}
