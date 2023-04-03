using Microsoft.EntityFrameworkCore;

namespace PickItEasy.Persistence.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            //context.Database.Migrate();
            context.Database.EnsureCreated();
        }
    }
}
