using Syntra.PartyApp.Models;
using Syntra.PartyApp.Site.Services;

namespace Syntra.PartyApp.Site.Components.Pages
{
    public partial class Friends
    {
        List<Person> FriendList { get; set; } = new List<Person>();
        Person? CurrentSelectedPerson { get; set; } = null;
        Address? CurrentSelectedAddress { get; set; } = null;

        PersonService PersonService { get; set; } = new PersonService();
        protected override void OnInitialized()
        {
            FriendList = PersonService.GetAllFriends();
            base.OnInitialized();
        }
        void PersonInfoSelected(string personId) {
            CurrentSelectedPerson=PersonService.FindFriend(personId);   
            if(CurrentSelectedPerson != null && string.IsNullOrWhiteSpace(CurrentSelectedPerson.AddressId)==false) {
                CurrentSelectedAddress = PersonService.FindAddress(CurrentSelectedPerson.AddressId);
            }
        }
    }
}
