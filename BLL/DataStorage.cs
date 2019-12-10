using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BLL
{
    
    public class DataStorage
    {
        public List<Customer> customers  = new List<Customer>() ;

        public List<Resume> resumes = new List<Resume>();

        public List<Unemployed> unemployeds = new List<Unemployed>();

        public List<Vacancy> vacancies = new List<Vacancy>();

        public DataStorage()
        {

            customers = new List<Customer>();

            resumes = new List<Resume>();

            unemployeds = new List<Unemployed>();

            vacancies = new List<Vacancy>();
        }



    }
}
