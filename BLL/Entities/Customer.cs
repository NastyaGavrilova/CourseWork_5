
using System;

namespace BLL
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string CustomerSurname { get; set; }

        public string CustomerCompany { get; set; }

        public Customer()
        {

        }

        public Customer(string customerName, string customerSurname, string customerCompany)
        {
            CustomerID = new Random().Next(0, 1000);
            CustomerName = customerName;
            CustomerSurname = customerSurname;
            CustomerCompany = customerCompany;
        }

        public Customer(int customerID, string customerName, string customerSurname, string customerCompany)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            CustomerSurname = customerSurname;
            CustomerCompany = customerCompany;
        }

        public override string ToString()
        {
            return $"{CustomerID} - {CustomerName} - {CustomerSurname} - {CustomerCompany}";
        }
    }
}
