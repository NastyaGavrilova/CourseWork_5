using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BLL
{
    public class ResumeService
    {
        private DataStorage repository;

        Serializer<DataStorage> serializer = new Serializer<DataStorage>();
        public ResumeService(DataStorage repository)
        {
            this.repository = repository;
        }
        
        public bool AddResume(string category, double salary, Unemployed unemployed)
        {
            Resume res = new Resume(unemployed, salary, category);
            
           

                repository.resumes.Add(res);

                serializer.Serialize(repository);

                return true;
            
           
        }

        public bool DeleteResume(Resume res)
        {
            try
            {
                repository.resumes.Remove(res);

                serializer.Serialize(repository);

                return true;
            }
            catch (Exception) { return false; }
        }

        public bool EditResume(Resume res, double salary, string category)
        {
            try
            {
                repository.resumes.Where(x => x.Unemployed.Name == res.Unemployed.Name &&
                x.Unemployed.Surname == res.Unemployed.Surname).FirstOrDefault().Category = category;

                repository.resumes.Where(x => x.Unemployed.Name == res.Unemployed.Name &&
                x.Unemployed.Surname == res.Unemployed.Surname).FirstOrDefault().Salary = salary;

                serializer.Serialize(repository);

                return true;
            }
            catch (Exception) { return false; }
        }

        public string GetInfo(Resume res)
        {
            return res.ToString();
        }

        public List<Resume> GetResumes()
        {
            return repository.resumes;
        }

        public List<Resume> GetSortedList()
        {
            return repository.resumes.OrderBy(x=>x.Salary).ToList();
        }
    }
}
