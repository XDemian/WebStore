using Microsoft.EntityFrameworkCore;
using WebStoreModel.Entities;

namespace WebStoreDAO.CoreDAO
{
    public class WebStoreContext : DbContext
    {
        // public WebStoreContext(DbContextOptions<WebStoreContext> options)
        //     : base(options)
        // {
        // }
        public WebStoreContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    // .UseLoggerFactory(ConsoleLoggerFactory)
                    .UseMySQL("server=25.1.131.56;database=webstore;user=serginho;password=1234");
                    // .UseNpgsql(DaoSettingsUtil.StringConexao, 
                    //     builder => 
                    //     {
                    //         builder.MigrationsAssembly("SisdurService");
                    //         builder.MigrationsHistoryTable(defaultHistoryMigrationsTableName, DaoSettingsUtil.DefaultSchema);
                    //     });
            }
        }

        private static string defaultHistoryMigrationsTableName = "WEBSTORE_HISTORICO_MIGRATIONS";

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
        }
    }
}