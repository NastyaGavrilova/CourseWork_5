
namespace BLL
{
    public class Resume
    {
        public Unemployed Unemployed { get; set; }

        public double Salary { get; set; }

        public string Category { get; set; }

        public Resume(Unemployed unemployed, double salary, string category)
        {
            Unemployed = unemployed;
            Salary = salary;
            Category = category;
        }

        public Resume()
        {

        }

        public override string ToString()
        {
            return $"{Unemployed.ToString()} - {Category} - {Salary}";
        }
    }
}
