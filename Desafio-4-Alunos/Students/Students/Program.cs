using Students.Interfaces;
using Students.Services;

namespace Students
{
    public class Program
    {
        static void Main(string[] args)
        {
            IPersonService _personService = new PersonService();
            _personService.PrintAllDatabaseData();
        }
    }
}