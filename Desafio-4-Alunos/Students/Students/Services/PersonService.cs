using Students.Entities;
using Students.Interfaces;

namespace Students.Services
{
    public sealed class PersonService : IPersonService
    {
        private const string _filePath = @"C:\ws-vs22\AcademyAtos\Desafio-4-Alunos\Students\Students\DataBase\DataBasePeopleAndStudents.dat";
        private const string _person = "Z";
        private const string _course = "Y";
        private const int _typeData = 0;

        public void PrintAllDatabaseData()
        {
            var dataFile = GetAllData();
            var dataSplited = SplitData(dataFile);

            var results = SeparatingInstances(dataSplited);

            var totalPeoples = results.Item1.Count();
            var totalStudents = results.Item2.Count();

            Console.WriteLine($"Total de Entidades Pessoa: {totalPeoples}");
            foreach (var person in results.Item1)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine($"Total de Entidades Aluno e Curso: {totalStudents}");
            foreach (var student in results.Item2)
            {
                Console.WriteLine(student);
            }
        }

        private string[] GetAllData()
        {
            return File.ReadAllLines(_filePath);
        }

        private (List<Person>, List<Student>) SeparatingInstances(List<string[]> fileLines)
        {
            var peoples = new List<Person>();
            var students = new List<Student>();

            string[] previousLine = null;
            var lastLine = fileLines[fileLines.Count - 1];

            foreach (var line in fileLines)
            {
                if (previousLine is not null)
                {
                    if (previousLine[_typeData] == _person && line[_typeData] == _person)
                        peoples.Add(InstantiatePerson(previousLine));

                    if (previousLine[_typeData] == _person && line[_typeData] == _course)
                        students.Add(InstantiateStudent(previousLine, line));

                    if (line[_typeData] == _person && line == lastLine)
                        peoples.Add(InstantiatePerson(line));
                }

                previousLine = line;
            }

            return (peoples, students);
        }

        private List<string[]> SplitData(string[] fileLines)
        {
            var dataSplited = new List<string[]>();

            for (int line = 1; line < fileLines.Length; line++)
            {
                dataSplited.Add(fileLines[line].Split('-'));
            }

            return dataSplited;
        }

        private Person InstantiatePerson(string[] dataPerson)
        {
            return new Person(dataPerson[1], dataPerson[2], dataPerson[3], dataPerson[4], dataPerson[5]);
        }

        private Student InstantiateStudent(string[] dataStudent, string[] dataCourse)
        {
            return new Student(
                new Course(dataCourse[1], dataCourse[2], dataCourse[3]),
                dataStudent[1],
                dataStudent[2],
                dataStudent[3],
                dataStudent[4],
                dataStudent[5]
                );
        }
    }
}
