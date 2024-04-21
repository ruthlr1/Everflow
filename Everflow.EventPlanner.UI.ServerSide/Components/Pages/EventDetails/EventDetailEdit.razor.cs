using Everflow.EventPlanner.UI.ServerSide.Components.Pages.Common;
using Microsoft.AspNetCore.Components;
using Everflow.EventPlanner.Application.Features.Events;
using Everflow.EventPlanner.Application.Features.Events.Upsert;
using Everflow.EventPlanner.Application.Features.People;

namespace Everflow.EventPlanner.UI.ServerSide.Components.Pages
{
    public class EventDetailEditBase : CommonEditComponentBase
    {
        [Inject] public IEventService EventService { get; set; }
        [Parameter] public int Id { get; set; }

        public UpsertEventDetailCommand Model { get; set; } = new UpsertEventDetailCommand();

        public override async Task SubmitValidForm()
        {
            try
            {
                var result = await EventService.UpsertEvents(Model);
                if (result != null && result.NumberRecordsUpdated > 0)
                {
                    NavBack();
                }

            }
            catch (Exception ex)
            {
                // todo need tohandle errors into some sort of display for user
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (Id > 0)
            {
                Model = await EventService.GetEventDetail(Id);
            }
        }

        public void NavBack()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}