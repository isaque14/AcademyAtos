namespace Students.Entities
{
    public class Person
    {
        public string Name { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string City { get; protected set; }
        public string RG { get; protected set; }
        public string CPF { get; protected set; }

        public Person(string name, string phoneNumber, string city, string rg, string cpf)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            City = city;
            RG = rg;
            CPF = cpf;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Phone Number: {PhoneNumber}, City: {City}, RG: {RG}, CPF: {CPF}";
        }
    }
}
