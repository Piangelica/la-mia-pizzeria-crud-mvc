
using Microsoft.EntityFrameworkCore;
using NetCore_01.Models;
using NetCore_1.Models;

namespace NetCore_01.Data
{
    public class PizzeContext: DbContext
    {
        public DbSet<Pizze> Pizze { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=blog_post;Integrated Security=True");
        }
    }
}

       /*public DbSet<Category> Categories { get; set; }
        public object Category { get; internal set; }
        public IEnumerable<object> Pizzas { get; internal set; }
       */
       
