namespace CSharp.Demo.Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            list.Add(new Student("John", "Doe",new Dictionary<string, double> { { "C#", 5.0 }, { "Huishoudkunde", 8.0} }));
            list.Add(new Student("Jane", "Doe", new Dictionary<string, double> { { "C#", 8.0 }, { "Wiskunde", 4.0 } }));
            list.Add(new Teacher("Filip", "Geens", ["C#", "SQL"]));
            list.Add(new Person() { FirstName = "Billy", LastName = "The Kid" });

            foreach (Person person in list)
            {
                Console.WriteLine("Resultaat van ShowProperties: ");
                Student? student = person as Student;
                if(person is Teacher teacher)
                {
                    Console.WriteLine(teacher.ShowProperties());
                }
                else if(student != null)
                {
                    Console.WriteLine(student.ShowProperties());
                }
                else
                {
                    Console.WriteLine(person.ShowProperties());
                }
                Console.WriteLine();
                Console.WriteLine("Resultaat van ToString(): ");
                Console.WriteLine(person.ToString());
                Console.WriteLine();
                Console.WriteLine("------------------------------------");
            }

            Console.ReadKey();

        }
    }
}
