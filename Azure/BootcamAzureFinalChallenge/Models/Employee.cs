namespace AzChallengeDio.Models
{
    public class Employee
    {
        public Employee() { }

        public Employee(int id, string name, string address, string extension, string professionalEmail, string department, decimal salary, DateTime admissionDate)
        {
            Id = id;
            Name = name;
            Address = address;
            Extension = extension;
            ProfessionalEmail = professionalEmail;
            Department = department;
            Salary = salary;
            AdmissionDate = admissionDate;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Extension { get; set; }
        public string ProfessionalEmail { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public DateTimeOffset? AdmissionDate { get; set; }
    }
}