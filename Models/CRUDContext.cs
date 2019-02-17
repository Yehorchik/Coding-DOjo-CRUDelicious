    using Microsoft.EntityFrameworkCore; 
    namespace CRUDelicious.Models
    {
        public class CRUDContext : DbContext
        {
            public CRUDContext(DbContextOptions<CRUDContext> options) : base(options) { }
        
            public DbSet<Dishes> dishes {get;set;}
            public DbSet<Chef> chefs {get;set;}
        }
    }
    