using Syntra.PartyApp.Models;

namespace Syntra.PartyApp.Site.Services.Contract
{
    public interface IPersonService
    {
        List<Person> GetAllFriends();
        List<Address> GetAllAddresses();
        Person? FindFriend(string id);
        Address? FindAddress(string id); 
    }
}
