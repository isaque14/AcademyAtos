namespace Students.Entities
{
    public sealed class Student : Person
    {
        public Course Course { get; set; }

        public Student(Course course, string name, string phoneNumber, string city, string rg, string cpf) 
            : base(name, phoneNumber, city, rg, cpf)
        {
            Course = course;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Phone Number: {PhoneNumber}, City: {City}, RG: {RG}, CPF: {CPF}\n" +
                   $"Course: {Course.ToString()}";
        }
    }
}
