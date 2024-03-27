using Syntra.PartyApp.Models;
using Syntra.PartyApp.Site.Components.Pages;
using Syntra.PartyApp.Site.Services.Contract;
using System.Text.Json;

namespace Syntra.PartyApp.Site.Services
{
	public class PersonService : IPersonService
	{
		const string JsonFileName = "friends.json";

		public PersonService() { }

		List<Person>? _friends = null;
		public string JsonFilePath => $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).TrimEnd('\\')}\{JsonFileName}";
		public Address? FindAddress(string id) => GetAllAddresses().Where(a => a.ID == id).FirstOrDefault();

		public Person? FindFriend(string id) => GetAllFriends().Where(f => f.ID == id).FirstOrDefault();

		public List<Person> GetAllFriends()
		{
			_friends = TryGetFriendsJson();
			if(_friends == null)
			{
				_friends = [
					 new Person() {ID="P1", FirstName="Filip" , AddressId = "A1", LastName ="Geens", Gender=Person.Genders.Male, Relation=Person.Relationships.Enemy },
				new Person() {ID="P2", FirstName = "Annick", AddressId="A1", LastName = "Geens", Gender = Person.Genders.Female, Relation = Person.Relationships.Lover },
				new Person() {ID="P3", FirstName = "Mohamed", AddressId = "A2", LastName = "El Hissaoui", Gender = Person.Genders.Male, Relation = Person.Relationships.Friend},
				new Person() {ID="P4", FirstName = "Yannick", LastName = "Anné", AddressId = "A3", Gender = Person.Genders.Male, Relation = Person.Relationships.Friend }
				 ];
				StoreFriendsAsJson(_friends);

			}
			return _friends;
		}



		public List<Address> GetAllAddresses()
		{
			return [
				new Address(){ID="A1",Street="LangeKorte Beeltenisstraat", HouseNumber="45", City="Antwerpen",ZipCode="2000", CountryId="BEL"},
				new Address(){ ID = "A2", Street = "Korte Dikke Gijsstraat", HouseNumber = "305", City = "Brussel", ZipCode = "1000", CountryId = "BEL" },
				new Address() { ID = "A3", Street = "Verre Lange Blaasstraat", HouseNumber = "687", City = "Lier", ZipCode = "2500", CountryId = "BEL" }
			];
		}
		public string AllFriendsToJson(List<Person> friends) => JsonSerializer.Serialize(friends, new JsonSerializerOptions() { WriteIndented = true });

		public void StoreFriendsAsJson(List<Person> friends)
		{
			var friendJson = AllFriendsToJson(friends);
			File.WriteAllText(JsonFilePath, friendJson);
		}
		private List<Person>? TryGetFriendsJson()
		{
			if(File.Exists(JsonFilePath))
			{
				string json = File.ReadAllText(JsonFilePath);
				return JsonSerializer.Deserialize<List<Person>>(json);
			}
			return null;
		}

	}
}
