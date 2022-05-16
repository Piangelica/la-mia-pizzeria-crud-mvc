
using Microsoft.EntityFrameworkCore;
using NetCore_01.Models;

namespace NetCore_01.Data
{
    public class BlogContext: DbContext
{
public DbSet<Pizze> Pizze{ get; set;}
protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=NomeDelDatabase;Integrated Security=True");
        }

    }
}
