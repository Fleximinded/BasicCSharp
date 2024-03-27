namespace Syntra.PartyApp.Models
{
    public class Person : ModelBase
    {
        public enum Genders { Male, Female, Neutral, Unknown }
        [Flags]
        public enum Relationships { Family = 1, Friend = 2, Enemy = 4, Lover = 8, OneNightStand = 16, Colleague = 32, Acquaintance = 64 };
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }=string.Empty;
        public DateOnly? BirthDate { get; set; } = null;
        public Genders Gender { get; set; } = Genders.Unknown;
        public Relationships Relation { get; set; }
        public string AddressId { get; set; } = string.Empty;
    }
}
