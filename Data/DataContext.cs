using api_1.Models;
using Microsoft.EntityFrameworkCore;

namespace api_1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
    }
}