using Everflow.EventPlanner.Application.Features.Events.QueryList;
using Everflow.EventPlanner.Application.Features.Events;
using MediatR;
using System.Reflection;
using Everflow.EventPlanner.Application.Common;
using Everflow.EventPlanner.Application.Features.Events.Upsert;
using Everflow.EventPlanner.Application.Features.People.Upsert;
using Everflow.EventPlanner.Application.Features.People;
using Everflow.EventPlanner.Application.Features.Alerts;

namespace Everflow.EventPlanner.UI.ServerSide.Register
{
    public class RegisterServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<UpsertPersonCommand, UpdateResult>, UpsertPersonCommandHandler>();
            services.AddScoped(typeof(IPersonService), typeof(PersonService));


            services.AddScoped<IRequestHandler<UpsertEventDetailCommand, UpdateResult>, UpsertEventDetailCommandHandler>();
            services.AddScoped<IRequestHandler<GetEventDetailLookupQuery, IList<EventDetailLookupModel>>, GetEventDetailLookupQueryHandler>();
            services.AddScoped(typeof(IEventService), typeof(EventService));


            services.AddScoped(typeof(AlertService));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
