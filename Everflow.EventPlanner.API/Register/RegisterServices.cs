using Everflow.EventPlanner.Application.Features.Events.QueryList;
using Everflow.EventPlanner.Application.Features.Events;
using Everflow.EventPlanner.Persistence.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Everflow.EventPlanner.Application.Features.Auth;

namespace Everflow.EventPlanner.API.Register
{
    public class RegisterServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IRequestHandler<GetMyEventsLookupQuery, IList<EventDetailLookupModel>>, GetMyEventsLookupQueryHandler>();
            services.AddScoped(typeof(IEventService), typeof(EventService));
            services.AddScoped(typeof(IAuthService), typeof(AuthService));
        }
    }
}
