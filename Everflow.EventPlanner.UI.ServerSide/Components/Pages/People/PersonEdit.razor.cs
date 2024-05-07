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
                if (result != null && result.IsSuccess)
                {
                    NavBack();
                    AlertService.SetSuccessMessage(base.DefaultSuccessMessage(Id, "Person"));
                }

            }
            catch (Exception ex)
            {
                AlertService.SetErrorMessage(ex);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (Id > 0)
            {
                Model = await PersonService.GetUpsert(Id);
            }

            await base.OnInitializedAsync();
        }

        public void NavBack()
        {
            NavigationManager.NavigateTo("/people");
        }
    }
}