using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Everflow.EventPlanner.Application.Features.People;
using Everflow.EventPlanner.Application.Features.People.QueryList;
using Microsoft.AspNetCore.Components;

namespace Everflow.EventPlanner.UI.ServerSide.Components.Pages.People
{
    public class PersonSelectorBase : ComponentBase
    {
        [Inject] public IPersonService PersonService { get; set; }

        [Parameter]public IEnumerable<int>? SelectedPersonIds { get; set; }
        [Parameter]public EventCallback<IEnumerable<int>?> SelectedPersonIdsChanged { get; set; }

        public IList<PersonLookupModel> Model { get; set; } = new List<PersonLookupModel>();

        public Func<PersonLookupModel, string> PersonName = p => p?.Name;

        private IEnumerable<PersonLookupModel>? _selectedPeople;
        public IEnumerable<PersonLookupModel>? SelectedPeople { get { return _selectedPeople; } set { _selectedPeople = value; OnPersonChanged(); } }

        protected override async Task OnInitializedAsync()
        {
            Model = await PersonService.GetAllPeople();
        }

        protected override void OnParametersSet()
        {
            if (SelectedPersonIds != null)
                _selectedPeople = Model.Where(x => SelectedPersonIds.Contains(x.PersonId));
            else
                _selectedPeople = null;
        }

        private void OnPersonChanged()
        {
            if (SelectedPeople == null)
                SelectedPersonIds = null;
            else
                SelectedPersonIds = SelectedPeople.Select(x => x.PersonId);

            SelectedPersonIdsChanged.InvokeAsync(SelectedPersonIds);
        }
    }
}