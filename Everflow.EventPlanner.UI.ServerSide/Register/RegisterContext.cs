using Everflow.EventPlanner.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Everflow.EventPlanner.UI.ServerSide.Register
{
    public class RegisterContext
    {
        public static void Register(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<EverflowContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
