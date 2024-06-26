﻿using Everflow.EventPlanner.Application.Features.Events;
using Everflow.EventPlanner.Application.Features.Events.QueryList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;
        private readonly IEventService _eventService;

        public EventController(ILogger<EventController> logger, IEventService eventService)
        {
            _logger = logger;
            _eventService = eventService;
        }


        [HttpGet]
        public async Task<IList<EventDetailLookupModel>> Get(int personId)
        {
            return await _eventService.GetMyEventsLookupQuery(personId);
        }
    }
}
