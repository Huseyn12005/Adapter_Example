namespace Adapter_Example
{

    class LegacyPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        public void Show()
        {
            Console.WriteLine($"Legacy Person: {FirstName} - {LastName} - {Birthdate.ToShortDateString()}");
        }
    }

    interface IPersonInfo
    {
        void DisplayInfo();
    }

    //Object Adapter
    class PersonObjectAdapter : IPersonInfo
    {
        private readonly LegacyPerson legacyPerson;

        public PersonObjectAdapter(LegacyPerson legacyPerson)
        {
            this.legacyPerson = legacyPerson;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Object Adapted Person: {legacyPerson.FirstName} - {legacyPerson.LastName} - {legacyPerson.Birthdate.ToShortDateString()}");
        }
    }

    class ClientObjectAdapter
    {
        public void ShowPersonInfo(IPersonInfo personInfo)
        {
            personInfo.DisplayInfo();
        }
    }


    //Class Adapter
    class PersonClassAdapter : LegacyPerson, IPersonInfo
    {
        public void DisplayInfo()
        {
            Console.WriteLine($"Class Adapted Person: {FirstName} {LastName}, born on {Birthdate.ToShortDateString()}");
        }
    }

    class ClientClassAdapter
    {
        public void ShowPersonInfoClass(IPersonInfo personInfo)
        {
            personInfo.DisplayInfo();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            LegacyPerson legacyPerson = new LegacyPerson
            {
                FirstName = "Huseyn",
                LastName = "Orucov",
                Birthdate = new DateTime(2005, 2, 28)
            };

            IPersonInfo adapter = new PersonObjectAdapter(legacyPerson);

            ClientObjectAdapter client = new ClientObjectAdapter();
            client.ShowPersonInfo(adapter);

            ClientClassAdapter client1 = new ClientClassAdapter();
        }
    }
}