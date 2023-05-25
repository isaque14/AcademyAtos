namespace Students.Entities
{
    public sealed class Course
    {
        public string RegistrationNumber { get; private set; }
        public string CourseCode { get; private set; }
        public string Name { get; set; }

        public Course(string registrationNumber, string courseCode, string name)
        {
            RegistrationNumber = registrationNumber;
            CourseCode = courseCode;
            Name = name;
        }

        public override string ToString()
        {
            return $"Registration Number: {RegistrationNumber}, Course Code: {CourseCode}, Name: {Name}";
        }
    }
}
