using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;

namespace BLL_Tests
{
    [TestClass]
    public class Tests
    {
        private CustomerService customerService;

        private UnemployedService unemployedService;

        private DataStorage repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new DataStorage();
            customerService = new CustomerService(repository);
            unemployedService = new UnemployedService(repository);
        }

        [TestMethod]
        public void Add_AddCustomer()
        {
            Assert.IsTrue(customerService.Add("", "", ""));
        }

        [TestMethod]
        public void Remove_RemoveCustomer()
        {
            var customer = new Customer("", "", "");
            repository.customers.Add(customer);

            Assert.IsTrue(customerService.Remove(customer));
        }

        [TestMethod]
        public void Edit_EditCustomer()
        {
            var customer = new Customer("", "", "");
            repository.customers.Add(customer);

            Assert.IsTrue(customerService.Edit(customer, "1", "1", "1"));
        }

        [TestMethod]
        public void GetInfoCustomer_ShouldReturn_Info_Of_Customer()
        {
            string customerss;
            string customer;
            var customer1 = new Customer("Ann", "", "");
            var customer2 = new Customer("", "", "");
            var customer3 = new Customer("", "", "");
            repository.customers.Add(customer1);
            repository.customers.Add(customer2);
            repository.customers.Add(customer3);
            customerss = customerService.GetInfo(customer1);
            customer = customer1.ToString();
            Assert.AreEqual(customer, customerss);
            
        }


        [TestMethod]
        public void GetCustomers_ShouldReturn_Customers()
        {
            List<Customer> customerss = new List<Customer>();
            var customer = new Customer("Ann", "", "");
            var customer1 = new Customer("Vika", "", "");
            var customer2 = new Customer("Lera", "", "");
            repository.customers.Add(customer);
            repository.customers.Add(customer1);
            repository.customers.Add(customer2);
            customerss = customerService.GetCustomers();
            Assert.IsTrue(customer == customerss[0] && customer1 == customerss[1] && customer2 == customerss[2]);
            
        }

        [TestMethod]
        public void GetSortedListByName_ShouldReturn_SortedByNameList_Of_Customer()   
        {
            List<Customer> customerss = new List<Customer>();
            var customer = new Customer("Bogdan", "", "");
            var customer1 = new Customer("Ann", "", "");
            var customer2 = new Customer("Vasya", "", "");
            repository.customers.Add(customer);
            repository.customers.Add(customer1);
            repository.customers.Add(customer2);
            customerss = customerService.GetSortedListByName();

            Assert.IsTrue(customer1 == customerss[0] && customer == customerss[1] && customer2 == customerss[2]);
        }

        [TestMethod]
        public void GetSortedListBySurname_ShouldReturn_SortedBySurnameList_Of_Customer()
        {
            List<Customer> customers = new List<Customer>();
            var customer = new Customer("", "Pupkin", "");
            var customer1 = new Customer("", "Federov", "");
            var customer2 = new Customer("", "Skopintsev", "");
            repository.customers.Add(customer);
            repository.customers.Add(customer1);
            repository.customers.Add(customer2);
            customers = customerService.GetSortedListBySurname();
            Assert.IsTrue(customer1 == customers[0]&&customer==customers[1]&&customer2==customers[2]);
        }

        [TestMethod]
        public void Add_AddUnemployed()
        {
            Assert.IsTrue(unemployedService.Add("", "", "", "", ""));
        }

        [TestMethod]
        public void Remove_RemoveUnemployed()
        {
            var unemployed = new Unemployed("", "", "", "", "");
            repository.unemployeds.Add(unemployed);

            Assert.IsTrue(unemployedService.Remove(unemployed));
        }

        [TestMethod]
        public void Edit_EditUnemployed()
        {
            var unemployed = new Unemployed("", "", "", "", "");
            repository.unemployeds.Add(unemployed);

            Assert.IsTrue(unemployedService.Edit(unemployed, "1", "1", "1", "1", "1"));
        }

        [TestMethod]
        public void GetInfo_ShoudReturn_Info_Of_Unemployed()
        {
            string unemployedss;
            string unemployed;
            var unemployed1 = new Unemployed("Ann", "", "","","");
            var unemployed2 = new Unemployed("", "", "","","");
            var unemployed3 = new Unemployed("", "", "","","");
            repository.unemployeds.Add(unemployed1);
            repository.unemployeds.Add(unemployed2);
            repository.unemployeds.Add(unemployed3);
            unemployedss = unemployedService.GetInfo(unemployed1);
            unemployed = unemployed1.ToString();
            Assert.AreEqual(unemployed, unemployedss);
            
        }

        [TestMethod]
        public void Search_ShouldReturn_Unemployed_By_KeyWord()
        {
            var unemployed = new Unemployed("vasya", "", "", "", "");
            repository.unemployeds.Add(unemployed);

            Assert.IsNotNull(unemployedService.Search("vasya"));
        }

        [TestMethod]
        public void GetSortedListBySurname_ShouldReturn_SortedBySurnameLIst_Of_Unemployed()
        {
           
            List<Unemployed> unemployedss = new List<Unemployed>();
            var unemployed = new Unemployed("", "Pupkin", "","","");
            var unemployed1 = new Unemployed("", "Federov", "","","");
            var unemployed2 = new Unemployed("", "Skopintsev", "","","");
            repository.unemployeds.Add(unemployed);
            repository.unemployeds.Add(unemployed1);
            repository.unemployeds.Add(unemployed2);
            unemployedss = unemployedService.GetSortedListBySurname();
            Assert.IsTrue(unemployed1 == unemployedss[0] && unemployed == unemployedss[1] && unemployed2 == unemployedss[2]);
        }

        [TestMethod]
        public void GetSortedListByName_ShouldReturn_SortedByNameList_of_Unemployed()
        {
            List<Unemployed> unemployedss = new List<Unemployed>();
            var unemployed = new Unemployed("Bogdan", "", "", "", "");
            var unemployed1 = new Unemployed("Ann", "", "", "", "");
            var unemployed2 = new Unemployed("Vasya", "", "", "", "");
            repository.unemployeds.Add(unemployed);
            repository.unemployeds.Add(unemployed1);
            repository.unemployeds.Add(unemployed2);
            unemployedss = unemployedService.GetSortedListByName();
            Assert.IsTrue(unemployed1 == unemployedss[0] && unemployed == unemployedss[1] && unemployed2 == unemployedss[2]);
        }
        
    }
}
