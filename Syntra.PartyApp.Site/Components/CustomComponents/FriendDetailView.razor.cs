using Microsoft.AspNetCore.Components;
using Syntra.PartyApp.Models;

namespace Syntra.PartyApp.Site.Components.CustomComponents
{
    public partial class FriendDetailView
    {
        [Parameter]
        public Person? SelectedPerson { get; set; } = null;
        [Parameter]
        public Address? SelectedAddress { get; set; } = null;
    }
}
