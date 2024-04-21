using Everflow.EventPlanner.Application.Common;
using Everflow.EventPlanner.Application.Features.Events;
using Everflow.EventPlanner.Application.Features.Events.QueryList;
using Everflow.EventPlanner.Application.Features.Events.Upsert;
using Everflow.EventPlanner.Application.Features.People;
using Everflow.EventPlanner.Application.Features.People.Upsert;
using MediatR;
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


            services.AddScoped<IRequestHandler<UpsertPersonCommand, UpdateResult>, UpsertPersonCommandHandler>();
            services.AddScoped(typeof(IPersonService), typeof(PersonService));


            services.AddScoped<IRequestHandler<UpsertEventDetailCommand, UpdateResult>, UpsertEventDetailCommandHandler>();
            services.AddScoped<IRequestHandler<GetEventDetailLookupQuery, IList<EventDetailLookupModel>>, GetEventDetailLookupQueryHandler>();
            services.AddScoped(typeof(IEventService), typeof(EventService));


            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
