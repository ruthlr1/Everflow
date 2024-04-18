using Everflow.EventPlanner.Application.Features.Events;
using Everflow.EventPlanner.Application.Features.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.UI.ServerSide
{
    public static class ServiceRegistry
    {
        public static void Register(IServiceCollection services)
        {
            // register application layer services
            // can use scrutor to do this easier but this will be fine for now

            services.AddScoped(typeof(IPersonService), typeof(PersonService));
            services.AddScoped(typeof(IEventService), typeof(EventService));


            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
