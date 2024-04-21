using Everflow.EventPlanner.Application.Features.Events.QueryList;
using Everflow.EventPlanner.Application.Features.Events;
using MediatR;
using System.Reflection;
using Everflow.EventPlanner.Application.Features.Auth;

namespace Everflow.EventPlanner.UI.ServerSide.Register
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
