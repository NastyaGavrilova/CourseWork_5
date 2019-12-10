using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BLL
{
    public class VacansyService
    {
        private DataStorage repository;
        Serializer<DataStorage> serializer = new Serializer<DataStorage>();
        public VacansyService(DataStorage repository)
        {
            this.repository = repository;
        }
        

        public bool AddVacancy(string cat, string name, double salary)
        {
            Vacancy vac = new Vacancy(name, salary, cat);
            repository.vacancies.Add(vac);

            serializer.Serialize(repository);

            return true;
        }

        public bool DeleteVacansy(Vacancy vac)
        {
            try
            {
                repository.vacancies.Remove(vac);

                serializer.Serialize(repository);

                return true;
            }
            catch (Exception) { return false; }
        }

        public bool EditVacansy(Vacancy vac, string cat, string name, double salary)
        {
            try
            {
                repository.vacancies.Where(x => x.Name == vac.Name && x.Salary == vac.Salary)
                    .FirstOrDefault().Name = name;

                repository.vacancies.Where(x => x.Name == vac.Name && x.Salary == vac.Salary)
                    .FirstOrDefault().Salary = salary;

                repository.vacancies.Where(x => x.Name == vac.Name && x.Salary == vac.Salary)
                    .FirstOrDefault().Category = cat;

                serializer.Serialize(repository);

                return true;
            }
            catch (Exception) { return false; }
        }

        public string GetInfo(Vacancy vac)
        {
            return vac.ToString();
        }

        public List<Vacancy> GetVacancies()
        {
            return repository.vacancies;
        }

        public List<Vacancy> GetSortedList()
        {
            return repository.vacancies.OrderBy(x=>x.Name).ToList();
        }

        public IOrderedEnumerable<Vacancy> Search(string word)
        {
            var query =
               from w in repository.vacancies
               where w.Name == word || w.Category == word
               orderby w.Name
               select w;

            return query;
        }
    }
}
