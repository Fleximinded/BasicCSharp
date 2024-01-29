namespace CSharp.Demo.GenericTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<PersonData> myList = new();
            myList.Add(new PersonData("John","De Meyer"));
            myList.Add(new PersonData("Filip", "Geens"));
            myList.Add(new PersonData("Yannick", "Anne"));
            Console.WriteLine(myList[0]);
            Console.WriteLine(myList[1]);
            Console.WriteLine(myList[2]);
            Console.WriteLine(myList[100]);
        }
    }
}
