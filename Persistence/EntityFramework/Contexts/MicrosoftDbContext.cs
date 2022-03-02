using Domain.Entities;
using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistence.EntityFramework.Contexts
{
    public class MicrosoftDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public MicrosoftDbContext(DbContextOptions<MicrosoftDbContext> options,IConfiguration configuration)
            :base(options)
        {
            _configuration = configuration;
        }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder.UseSqlServer(_configuration.GetSection("ConnectionStrings").Value));
            }
           
        }

        public DbSet<User> Users { get; set; }
    }
}
