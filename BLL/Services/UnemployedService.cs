using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class UnemployedService
    {
        private DataStorage repository;
        Serializer<DataStorage> serializer = new Serializer<DataStorage>();
 

        public UnemployedService(DataStorage repository)
        {
            this.repository = repository;
        }
        public bool Add(string name, string surname, string birthday, string university, string profession)
        {

            Unemployed unemployed = new Unemployed(name, surname, birthday, university, profession);

            repository.unemployeds.Add(unemployed);
            serializer.Serialize(repository);

            return true;
        }

        public bool Remove(Unemployed en)
        {
            try
            {
                repository.unemployeds.Remove(en);

                serializer.Serialize(repository);

                return true;
            }
            catch (Exception) { return false; }
        }

        public bool Edit(Unemployed en, string name, string surname, string birthday, string university, string proff)
        {
            try
            {
                repository.unemployeds.Where(x => x.ID == en.ID).FirstOrDefault().Name = name;
                repository.unemployeds.Where(x => x.ID == en.ID).FirstOrDefault().Surname = surname;
                repository.unemployeds.Where(x => x.ID == en.ID).FirstOrDefault().Birthday = birthday;
                repository.unemployeds.Where(x => x.ID == en.ID).FirstOrDefault().University = university;
                repository.unemployeds.Where(x => x.ID == en.ID).FirstOrDefault().Profession = proff;

                serializer.Serialize(repository);

                return true;
            }
            catch (Exception) { return false; }
        }

        public string GetInfo(Unemployed en)
        {
            return en.ToString();
        }

        public List<Unemployed> GetUnemployeds()
        {
            return repository.unemployeds;
        }

        public List<Unemployed> GetSortedListByName()
        {
            return repository.unemployeds.OrderBy(x => x.Name).ToList();
        }

        public List<Unemployed> GetSortedListBySurname()
        {
            return repository.unemployeds.OrderBy(x => x.Surname).ToList();
        }

        public IOrderedEnumerable<Unemployed> Search(string word)
        {
            var query =
               from w in repository.unemployeds
               where w.Name == word || w.Surname == word || 
               w.University == word || w.Profession == word
               orderby w.Name
               select w;

            return query;
        }
    }
}
