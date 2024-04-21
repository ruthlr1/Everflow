
using Everflow.EventPlanner.Application.Features.Events;
using Everflow.EventPlanner.Application.Features.Events.QueryList;
using Everflow.EventPlanner.UI.ServerSide.Components.Pages.Common;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.UI.ServerSide.Components.Pages
{
    public class HomeBase : CommonComponentBase
    {
        [Inject] public IEventService EventService { get; set; }

        public void AddNewClicked()
        {
            NavigationManager.NavigateTo("/events/new");
        }

        public IList<EventDetailLookupModel> Model { get; set; } = new List<EventDetailLookupModel>();
        private bool _showUpcomingEventsToggle = true;
        public bool ShowUpcomingEventsToggle { get { return _showUpcomingEventsToggle; } set { _showUpcomingEventsToggle = value; OnToggleChanged(); } }
        protected override async Task OnInitializedAsync()
        {
            await RefreshData();
        }

        private async void OnToggleChanged()
        {
            await RefreshData();
        }

        private async Task RefreshData()
        {
            DateTime filterDate = ShowUpcomingEventsToggle ? DateTime.Now : DateTime.MinValue;
            Model = await EventService.GetListAllEvents(filterDate);
            await InvokeAsync(StateHasChanged);
        }

        public void EditRecord(EventDetailLookupModel item)
        {
            NavigationManager.NavigateTo($"/events/{item.EventDetailId}");
        }
    }
}
