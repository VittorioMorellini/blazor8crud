using Crud.shared.Entity;
using Microsoft.EntityFrameworkCore;

namespace Crud.shared.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
    }
}
