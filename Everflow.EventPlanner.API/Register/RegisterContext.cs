using Everflow.EventPlanner.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.API.Register
{
    public class RegisterContext
    {
        public static void Register(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<EverflowContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);
        }
    }
}
