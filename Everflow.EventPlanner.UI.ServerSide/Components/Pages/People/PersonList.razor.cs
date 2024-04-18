using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Everflow.EventPlanner.UI.ServerSide.Components.Pages.Common;
using Microsoft.AspNetCore.Components;

namespace Everflow.EventPlanner.UI.ServerSide.Components.Pages.People
{
    public class PersonListBase : CommonComponentBase
    {

        public void AddNewClicked()
        {
            NavigationManager.NavigateTo("/people/new");
        }
    }
}