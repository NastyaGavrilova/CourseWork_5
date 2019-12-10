using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class CustomerService
    {
        private DataStorage repository;

        Serializer<DataStorage> serializer = new Serializer<DataStorage>();

        public CustomerService(DataStorage repository)
        {
            this.repository = repository;
        }

       

        public bool Add(string customerName, string customerSurname, string customerCompany)
        {
            Customer customer = new Customer(customerName, customerSurname, customerCompany);

            repository.customers.Add(customer);

            serializer.Serialize(repository);

            return true;
        }

        public bool Remove(Customer customer)
        {
            try
            {
                repository.customers.Remove(customer);

                serializer.Serialize(repository);

                return true;
            }
            catch (Exception) { return false; }
        }

        public bool Edit(Customer cust, string customerName, string customerSurname, string customerCompany)
        {
            try
            {
                repository.customers.Where(x => x.CustomerID == cust.CustomerID).FirstOrDefault().CustomerName = customerName;
                repository.customers.Where(x => x.CustomerID == cust.CustomerID).FirstOrDefault().CustomerSurname = customerSurname;
                repository.customers.Where(x => x.CustomerID == cust.CustomerID).FirstOrDefault().CustomerCompany = customerCompany;

                serializer.Serialize(repository);

                return true;
            }
            catch (Exception) { return false; }
        }

        public string GetInfo(Customer cust)
        {
            return cust.ToString();
        }

        public List<Customer> GetCustomers()
        {
            return repository.customers;
        }

        public List<Customer> GetSortedListByName()
        {
            return repository.customers.OrderBy(x => x.CustomerName).ToList();
        }

        public List<Customer> GetSortedListBySurname()
        {
            return repository.customers.OrderBy(x => x.CustomerSurname).ToList();
        }
    }
}
