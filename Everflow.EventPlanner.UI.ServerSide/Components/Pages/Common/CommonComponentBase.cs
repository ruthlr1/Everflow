using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.UI.ServerSide.Components.Pages.Common
{
    public abstract class CommonComponentBase : ComponentBase
    {
        [Inject] public NavigationManager NavigationManager { get; set; }


    }
}
