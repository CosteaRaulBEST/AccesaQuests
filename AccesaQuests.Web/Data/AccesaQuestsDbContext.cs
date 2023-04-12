using AccesaQuests.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AccesaQuests.Web.Data
{
    public class AccesaQuestsDbContext : DbContext
    {
        public AccesaQuestsDbContext(DbContextOptions<AccesaQuestsDbContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
