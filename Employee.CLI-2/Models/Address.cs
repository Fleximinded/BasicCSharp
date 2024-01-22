namespace Employee.CLI.Models
{
    public class Address
    {
        public Address()        {                        }
        public string Street { get; set; } = string.Empty;
        public string HouseNumber { get; set; } = string.Empty;   
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string? Country { get; set; } = null;
        public override string ToString()
        {
            return $"{Street} {HouseNumber}, {ZipCode} {City}";
        }
    }
}