namespace CSharp.Demo.Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dit is een demo van inheritance");
            Demo1();
            Console.WriteLine();
            Console.WriteLine("Druk op een toets om naar de volgende demo te gaan");
            Console.ReadKey();
            Console.WriteLine("Dit is een demo van casting");
            Demo2();
            Console.WriteLine();
            Console.WriteLine("Druk op een toets om naar de volgende demo te gaan");
            Console.ReadKey();
            Console.WriteLine("Dit is een demo van Late and Early binding");
            Demo3();

        }

        private static void Demo3()
        {
            List<Person> list = [
                new Person() { FirstName = "Billy", LastName = "The Kid" },
                new Student("John", "Doe", new Dictionary<string, double> { { "C#", 5.0 }, { "Huishoudkunde", 8.0 } }),
                new Teacher("Frits", "Rits", ["Economie", "Wiskunde"])];
            Console.WriteLine("Functie met early binding (new)");
            foreach (Person person in list)
            {
                Console.WriteLine($"persoon1.Print() => {person.EarlyBindingPrint()}");
            }
            Console.WriteLine("Functie met late binding (virtual - override)");
            foreach(Person person in list)
            {
                Console.WriteLine($"persoon1.Print() => {person.RealPrint()}");
            }


        }

        static void Demo1()
        {
            List<Person> list = new List<Person>();
            list.Add(new Student("John", "Doe", new Dictionary<string, double> { { "C#", 5.0 }, { "Huishoudkunde", 8.0 } }));
            list.Add(new Student("Jane", "Doe", new Dictionary<string, double> { { "C#", 8.0 }, { "Wiskunde", 4.0 } }));
            list.Add(new Teacher("Filip", "Geens", ["C#", "SQL"]));
            list.Add(new Person() { FirstName = "Billy", LastName = "The Kid" });

            foreach(Person person in list)
            {
                Console.WriteLine("Resultaat van ShowProperties: ");
                Student? student = person as Student;
                if(person is Teacher teacher)
                {
                    Console.WriteLine(teacher.EarlyBindingPrint());
                }
                else if(student != null)
                {
                    Console.WriteLine(student.EarlyBindingPrint());
                }
                else
                {
                    Console.WriteLine(person.EarlyBindingPrint());
                }
                Console.WriteLine();
                Console.WriteLine("------------------------------------");
            }
            Console.WriteLine();
        }
        static void Demo2()
        {

            Person persoon1 = new Person() { FirstName = "Billy", LastName = "The Kid" };
            Student student1 = new Student("John", "Doe", new Dictionary<string, double> { { "C#", 5.0 }, { "Huishoudkunde", 8.0 } });
            Person persoon2 = new Student("Frits", "Rits", new Dictionary<string, double> { { "Economie", 8.0 }, { "Wiskunde", 4.0 } });
            Console.WriteLine("We voegen volgende personen en studenten toe: ");
            Console.WriteLine();
            Console.WriteLine($"persoon1.Print() => {persoon1.EarlyBindingPrint()}");
            Console.WriteLine($"student1.Print() => {student1.EarlyBindingPrint()}");
            Console.WriteLine($"persoon2.Print() => {persoon2.EarlyBindingPrint()}");
            Console.WriteLine();
            Console.WriteLine("Druk op een toets om naar de volgende stap te gaan");
            Console.ReadKey();
            // we casten een student naar een persoon
            Console.WriteLine("We downcasten student1 naar studentAsPerson en roepen daarna de print functie van studentAsPerson aan: ");
            Person studentAsPerson = student1;
            Console.WriteLine($"studentAsPerson.Print() => {studentAsPerson.EarlyBindingPrint()}");
            Console.WriteLine();
            // cast terug van persoon (oorspronkelijk onze student) naar een andere referentie van student 
            Console.WriteLine("We upcasten studentAsPerson naar een nieuwe referentie, dummyStudent, en roepen daarna de print functie van dummyStudent aan: ");
            Console.WriteLine();
            Student dummyStudent = (Student)studentAsPerson;
            Console.WriteLine(dummyStudent.EarlyBindingPrint());
            Console.WriteLine();
            try
            {
                Console.WriteLine("We upcasten persoon1 naar een student, notAStudent, en roepen daarna de print functie van notAStudent aan: ");
                Student notAStudent = (Student)persoon1;
                Console.WriteLine($"notAStudent.Print() => {notAStudent.EarlyBindingPrint()}");
            }
            catch(InvalidCastException ex)
            {
                Console.WriteLine($"Omdat persoon1 geen student is, krijgen we een runtime exception van het type InvalidCastException");
                Console.WriteLine($"Deze Exception ziet er als volgt uit: {ex.ToString()}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Druk op een toets om naar de volgende stap te gaan");
            Console.ReadKey();
            // We veranderen de voornaam van de dummyStudent naar Jane.
            // Hiermee veranderen we ook de voornaam van de student1, omdat dit dezelfde referentie is.
            // Ook de voornaam in studentAsPerson verandert mee, omdat dit ook dezelfde referentie is!
            dummyStudent.FirstName = "Jane";
            Console.WriteLine();
            Console.WriteLine("Na de voornaamswijziging van dummyStudent naar Jane, ziet onze list er als volgt uit: ");
            Console.WriteLine();
            Console.WriteLine($"persoon1.Print() => {persoon1.EarlyBindingPrint()}");
            Console.WriteLine($"student1.Print() => {student1.EarlyBindingPrint()}");
            Console.WriteLine($"persoon2.Print() => {persoon2.EarlyBindingPrint()}");
            Console.WriteLine($"studentAsPerson.Print() => {studentAsPerson.EarlyBindingPrint()}");
            Console.WriteLine($"dummyStudent.Print() => {dummyStudent.EarlyBindingPrint()}");
            Console.WriteLine();
            Console.WriteLine("Druk op een toets om naar de volgende stap te gaan");
            Console.ReadKey();
            // Casten van een persoon naar een student met behulp van de as operator
            Console.WriteLine("We casten persoon2 naar student2 met behulp van de as operator en roepen daarna de print functie van student2 aan: ");
            Student? student2 = persoon2 as Student;
            if(student2 != null)
            {
                Console.WriteLine($"student2.Print() => {student2.EarlyBindingPrint()}");
            }
            else
            {
                Console.WriteLine($"{persoon2.EarlyBindingPrint()} is geen student");
            }
            Console.WriteLine();
            Console.WriteLine("We casten persoon1 naar student3 met behulp van de as operator en roepen daarna de print functie van student3 aan: ");
            Student? student3 = persoon1 as Student;
            if(student3 != null)
            {
                Console.WriteLine($"student3.Print() => {student3.EarlyBindingPrint()}");
            }
            else
            {
                Console.WriteLine($"{persoon1.EarlyBindingPrint()} is geen student");
            }
            Console.WriteLine();
            Console.WriteLine("Druk op een toets om naar de volgende stap te gaan");
            Console.ReadKey();
            Console.WriteLine();
            // Casten van een persoon naar een student met behulp van de is operator
            Console.WriteLine("We casten persoon2 naar student4 met behulp van de is operator en roepen daarna de print functie van student4 aan: ");
            Console.WriteLine();
            if(persoon1 is Student stud)
            {
                Console.WriteLine($"stud.Print() => {stud.EarlyBindingPrint()}");
            }
            else
            {
                Console.WriteLine($"{persoon1.EarlyBindingPrint()} is geen student");
            }
            Console.WriteLine();
            Console.WriteLine("We casten persoon2 naar student5 met behulp van de is operator en roepen daarna de print functie van student5 aan: ");
            Console.WriteLine();
            if(persoon2 is Student stud2)
            {
                Console.WriteLine($"stud2.Print() => {stud2.EarlyBindingPrint()}");
            }
            else
            {
                Console.WriteLine($"{persoon2.EarlyBindingPrint()} is geen student");
            }
            Console.WriteLine();
            Console.WriteLine("Druk op een toets om deze demo te eindigen");
            Console.ReadKey();
        }
    }
}
