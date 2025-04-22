using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SetecBackendCSharp.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Define sua connection string (a mesma do appsettings.json)
            optionsBuilder.UseMySql(
                "server=localhost;port=3306;database=ccapstools_app_backend;user=root;password=admin",
                ServerVersion.AutoDetect("server=localhost;port=3306;database=ccapstools_app_backend;user=root;password=admin"
)
            );

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
