using Everflow.EventPlanner.Application.Features.Alerts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.UI.ServerSide.Components.Pages.Common
{
    public abstract class CommonEditComponentBase : CommonComponentBase
    {
        [Inject] public AlertService AlertService { get; set; }
        public abstract Task SubmitValidForm();

        protected override Task OnInitializedAsync()
        {
            AlertService.ClearAlert();
            return base.OnInitializedAsync();
        }

        public virtual async Task SubmitForm(EditContext editContext)
        {
            AlertService.ClearAlert();
            if (editContext.Validate())
            {
                await SubmitValidForm();
            }
        }

        public string DefaultSuccessMessage(int id, string entityName)
        {
            if(id == 0)
                return $"{entityName} added successfully";
            else
                return $"{entityName} updated successfully";
        }
    }
}
