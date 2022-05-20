using NetCore_1.Models;

namespace NetCore_01.Models
{
    public class PostCategories
    {
        public Pizze pizze { get; set; }
        public List<Category>? Categories { get; set; }
    }
}

