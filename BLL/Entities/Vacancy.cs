
namespace BLL
{
    public class Vacancy
    {
        public string Name { get; set; }

        public double Salary { get; set; }

        public string Category { get; set; }

        public Vacancy()
        {

        }

        public Vacancy(string name, double salary, string category)
        {
            Name = name;
            Salary = salary;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Name} - {Salary} - {Category}";
        }
    }
}
