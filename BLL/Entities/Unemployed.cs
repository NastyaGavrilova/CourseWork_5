
using System;

namespace BLL
{
    public class Unemployed
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Birthday { get; set; }

        public string University { get; set; }

        public string Profession { get; set; }

        public Unemployed(string name, string surname,
            string birthday, string university, string profession)
        {
            ID = new Random().Next(0, 1000);
            Name = name;
            Surname = surname;
            Birthday = birthday;
            University = university;
            Profession = profession;
        }

        public Unemployed(int iD, string name, string surname,
            string birthday, string university, string profession)
        {
            ID = iD;
            Name = name;
            Surname = surname;
            Birthday = birthday;
            University = university;
            Profession = profession;
        }

        public Unemployed()
        {

        }

        public override string ToString()
        {
            return $"{Name} - {Surname} - {Birthday} - {University} - {Profession}";
        }
    }
}
