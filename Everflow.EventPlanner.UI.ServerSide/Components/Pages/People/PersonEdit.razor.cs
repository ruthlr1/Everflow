using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Everflow.EventPlanner.Application.Features.People;
using Everflow.EventPlanner.Application.Features.People.Upsert;
using Everflow.EventPlanner.UI.ServerSide.Components.Pages.Common;
using Microsoft.AspNetCore.Components;

namespace Everflow.EventPlanner.UI.ServerSide.Components.Pages.People
{
    public class PersonEditBase : CommonEditComponentBase
    {
        [Inject] public IPersonService PersonService { get; set; }
        [Parameter] public int Id { get; set; }

        public UpsertPersonCommand Model { get; set; } = new UpsertPersonCommand();

        public override async Task SubmitValidForm()
        {
            try
            {
                var result = await PersonService.UpsertPerson(Model);
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

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        public void NavBack()
        {
            NavigationManager.NavigateTo("/people");
        }
    }
}