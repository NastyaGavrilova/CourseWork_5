using System;
using System.Linq;
using BLL;
using DAL;
using System.Text.RegularExpressions;

namespace PL
{
    public class Menu
    {

        private DataStorage _repository;

        public CustomerService customerService;

        public ResumeService resumeService;

        public UnemployedService unemployedservice;

        public VacansyService vacansyService;

        Serializer<DataStorage> serializer = new Serializer<DataStorage>();

        public Menu(DataStorage repository, CustomerService customerService,
            ResumeService resumeService, UnemployedService unemployedservice, VacansyService vacansyService)
        {
            _repository = repository;
            this.customerService = customerService;
            this.resumeService = resumeService;
            this.unemployedservice = unemployedservice;
            this.vacansyService = vacansyService;
        }

        public Menu()
        {
            _repository = (DataStorage)serializer.Deserialize();
            Initialize();
        }

        private void Initialize()
        {
            if (_repository == null)
            {
                _repository = new DataStorage();
            }

            customerService = new CustomerService(_repository);

            resumeService = new ResumeService(_repository);

            unemployedservice = new UnemployedService(_repository);

            vacansyService = new VacansyService(_repository);
        }

        public void ShowMainMenu()
        {
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.WriteLine("1. Unemployeds");
                    Console.WriteLine("2. Vacancys");
                    Console.WriteLine("3. Resumes");
                    Console.WriteLine("4. Customers");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            ShowUnemployedMenu();
                            break;
                        case 2:
                            ShowVacansyMenu();
                            break;
                        case 3:
                            ShowResumeMenu();
                            break;
                        case 4:
                            ShowCustomerMenu();
                            break;
                        default:
                            Console.WriteLine("Wrong choice!");
                            break;
                    }
                }
                catch (Exception c) { Console.WriteLine(c.Message); Console.ReadKey(); }
            }

        }

        public void ShowCustomerMenu()
        {
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.WriteLine("1. Add Customer");
                    Console.WriteLine("2. Remove Customer");
                    Console.WriteLine("3. Edit Customer");
                    Console.WriteLine("4. Get Customer Info");
                    Console.WriteLine("5. Get Sorted List By Name");
                    Console.WriteLine("6. Get Sorted List By Surname");
                    Console.WriteLine("0. Main");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddCustomer();
                            break;
                        case 2:
                            RemoveCustomer();
                            break;
                        case 3:
                            EditCustomer();
                            break;
                        case 4:
                            GetCustomerInfo();
                            break;
                        case 5:
                            GetCustomersSortedByName();
                            break;
                        case 6:
                            GetCustomersSortedBySurname();
                            break;
                        case 0:
                            ShowMainMenu();
                            break;
                        default:
                            Console.WriteLine("Wrong choice!");
                            break;
                    }
                }
                catch (Exception c) { Console.WriteLine(c.Message); Console.ReadKey(); }
            }
        }



        private void AddCustomer()
        {

            try
            {
                string Name = @"^[A-Z]{1}[a-z]{1,}";
                string Surname = @"^[A-Z]{1}[a-z]{1,}";
                string Company = @"^[A-Z]{1}[a-z]{1,}";
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Surname: ");
                string surname = Console.ReadLine();
                Console.WriteLine("Company: ");
                string company = Console.ReadLine();
                Regex regex = new Regex(Name);
                Regex regex1 = new Regex(Surname);
                Regex regex2 = new Regex(Company);
                if (!(regex.IsMatch(name)))
                {
                    Console.WriteLine("Name no varified. Try again");
                    throw new Exception();
                }

                if (!(regex1.IsMatch(surname)))
                {
                    Console.WriteLine("Surname no varified. Try again");
                    throw new Exception();
                }

                if (!(regex2.IsMatch(company)))
                {
                    Console.WriteLine("Company no varified. Try again.");
                    throw new Exception();
                }

                else {customerService.Add(name, surname, company);}
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong enter!");
                Console.ReadKey();
            }
        }

        

        private void RemoveCustomer()
        {
            var customer = GetCustomer();

            if (customer != null)
            {
                customerService.Remove(customer);
            }
        }

        private void EditCustomer()
        {
            var customer = GetCustomer();

            if (customer != null)
            {
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Surname: ");
                string surname = Console.ReadLine();
                Console.WriteLine("Company: ");
                string company = Console.ReadLine();

                customerService.Edit(customer, name, surname, company);
            }
        }

        private void GetCustomerInfo()
        {
            var customer = GetCustomer();

            if (customer != null)
            {
                Console.WriteLine(customerService.GetInfo(customer));
            }
        }

        private void GetCustomersSortedByName()
        {
            foreach (var item in customerService.GetSortedListByName())
            {
                Console.WriteLine(item.ToString() + '\n');
            }
        }

        private void GetCustomersSortedBySurname()
        {
            foreach (var item in customerService.GetSortedListBySurname())
            {
                Console.WriteLine(item.ToString() + '\n');
            }
        }

        public void ShowResumeMenu()
        {
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.WriteLine("1. Add Resume");
                    Console.WriteLine("2. Remove Resume");
                    Console.WriteLine("3. Edit Resume");
                    Console.WriteLine("4. Get Resume Info");
                    Console.WriteLine("5. Get Sorted List");
                    Console.WriteLine("0. Main");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddResume();
                            break;
                        case 2:
                            RemoveResume();
                            break;
                        case 3:
                            EditResume();
                            break;
                        case 4:
                            GetResumeInfo();
                            break;
                        case 5:
                            GetSortedResumeList();
                            break;
                        case 0:
                            ShowMainMenu();
                            break;
                        default:
                            Console.WriteLine("Wrong choice!");
                            break;
                    }
                }
                catch (Exception c) { Console.WriteLine(c.Message); Console.ReadKey(); }
            }

        }

        private void AddResume()
        {
            try
            {
                var unemployed = GetUnemployed();

                if (unemployed != null)
                {
                    string Category = @"^[A-Z]{1}[a-z]{1,}";
                    string Salary = @"^[0-9]{7}";
                    Regex regex = new Regex(Salary);
                    Regex regex1 = new Regex(Category);
                    Console.WriteLine("Category: ");
                    string category = Console.ReadLine();
                    Console.WriteLine("Salary: ");
                    double salary = double.Parse(Console.ReadLine());
                    if (!(regex1.IsMatch(category)))
                    {
                        Console.WriteLine("Category no varified. Try again");
                        throw new Exception();
                    }
                    if (!(regex.IsMatch(salary.ToString())))
                    {
                        Console.WriteLine("Salary no varified. Try again");
                        throw new Exception();
                    }
                    else { resumeService.AddResume(category, salary, unemployed); }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong enter!");
                Console.ReadKey();
            }
        }

        private void RemoveResume()
        {
            var resume = GetResume();

            if (resume != null)
            {
                resumeService.DeleteResume(resume);
            }
        }

        private void EditResume()
        {
            var resume = GetResume();

            if (resume != null)
            {
                Console.WriteLine("Salary: ");
                double salary = double.Parse(Console.ReadLine());
                Console.WriteLine("Category: ");
                string category = Console.ReadLine();

                resumeService.EditResume(resume, salary, category);
            }
        }

        private void GetResumeInfo()
        {
            var resume = GetResume();

            if (resume != null)
            {
                Console.WriteLine(resume.ToString());
            }
        }

        private void GetSortedResumeList()
        {
            foreach (var item in resumeService.GetSortedList())
            {
                Console.WriteLine(item.ToString() + '\n');
            }
        }

        public void ShowUnemployedMenu()
        {
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.WriteLine("1. Add Unemployed");
                    Console.WriteLine("2. Remove Unemployed");
                    Console.WriteLine("3. Edit Unemployed");
                    Console.WriteLine("4. Get Unemployed Info");
                    Console.WriteLine("5. Get Sorted List By Name");
                    Console.WriteLine("6. Get Sorted List By Surname");
                    Console.WriteLine("7. Search");
                    Console.WriteLine("0. Main");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddUnemployed();
                            break;
                        case 2:
                            RemoveUnemployed();
                            break;
                        case 3:
                            EditUnemployed();
                            break;
                        case 4:
                            GetUnemployedInfo();
                            break;
                        case 5:
                            GetSortedUnemployedListByName();
                            break;
                        case 6:
                            GetSortedUnemployedListBySurname();
                            break;
                        case 7:
                            UnemployedSearch();
                            break;
                        case 0:
                            ShowMainMenu();
                            break;
                        default:
                            Console.WriteLine("Wrong choice!");
                            break;
                    }
                }
                catch (Exception c) { Console.WriteLine(c.Message); Console.ReadKey(); }
            }
        }

        private void UnemployedSearch()
        {
            Console.WriteLine("Word for search: ");
            foreach (var item in unemployedservice.Search(Console.ReadLine()))
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void AddUnemployed()
        {
            try
            {
                string Name = @"^[A-Z]{1}[a-z]{1,}";
                string Surname = @"^[A-Z]{1}[a-z]{1,}";
                string University = @"^[A-Z]{1,5}";
                string Profession = @"^[A-Z]{1}[a-z]{1,}";
                Regex regex = new Regex(Name);
                Regex regex1 = new Regex(Surname);
                Regex regex2 = new Regex(University);
                Regex regex3 = new Regex(Profession);
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Surname: ");
                string surname = Console.ReadLine();
                Console.WriteLine("Birthday: ");
                string birthday = Console.ReadLine();
                Console.WriteLine("University: ");
                string university = Console.ReadLine();
                Console.WriteLine("Proffesion: ");
                string proff = Console.ReadLine();
                if (!(regex.IsMatch(name)))
                {
                    Console.WriteLine("Name no varified. Try again");
                    throw new Exception();

                }

                if (!(regex1.IsMatch(surname)))
                {
                    Console.WriteLine("Surname no varified. Try again");
                    throw new Exception();

                }

                if (!(regex2.IsMatch(university)))
                {
                    Console.WriteLine("University no varified. Try again");
                    throw new Exception();
                }

                if (!(regex3.IsMatch(proff)))
                {
                    Console.WriteLine("Profession no varified. Try again");
                    throw new Exception();

                }
                else { unemployedservice.Add(name, surname, birthday, university, proff); }
               
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong enter!");
                Console.ReadKey();
            }
        }

        private void RemoveUnemployed()
        {
            var unemployed = GetUnemployed();

            if (unemployed != null)
            {
                unemployedservice.Remove(unemployed);
            }
        }

        private void EditUnemployed()
        {
            var unemployed = GetUnemployed();

            if (unemployed != null)
            {
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Surname: ");
                string surname = Console.ReadLine();
                Console.WriteLine("Birtday: ");
                string birthday = Console.ReadLine();
                Console.WriteLine("University: ");
                string university = Console.ReadLine();
                Console.WriteLine("Proffesion: ");
                string proff = Console.ReadLine();

                unemployedservice.Edit(unemployed, name, surname, birthday, university, proff);
            }
        }

        private void GetUnemployedInfo()
        {
            var unemployed = GetUnemployed();

            if (unemployed != null)
            {
                Console.WriteLine(unemployed.ToString());
            }
        }

        private void GetSortedUnemployedListByName()
        {
            foreach (var item in unemployedservice.GetSortedListByName())
            {
                Console.WriteLine(item.ToString() + '\n');
            }
        }

        private void GetSortedUnemployedListBySurname()
        {
            foreach (var item in unemployedservice.GetSortedListBySurname())
            {
                Console.WriteLine(item.ToString() + '\n');
            }
        }

        public void ShowVacansyMenu()
        {
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.WriteLine("1. Add Vacansy");
                    Console.WriteLine("2. Remove Vacansy");
                    Console.WriteLine("3. Edit Vacansy");
                    Console.WriteLine("4. Get Vacansy Info");
                    Console.WriteLine("5. Get Sorted List");
                    Console.WriteLine("6. Search");
                    Console.WriteLine("0. Main");

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddVacansy();
                            break;
                        case 2:
                            RemoveVacansy();
                            break;
                        case 3:
                            EditVacansy();
                            break;
                        case 4:
                            GetVacansyInfo();
                            break;
                        case 5:
                            GetSortedVacansysList();
                            break;
                        case 6:
                            VacansySearch();
                            break;
                        case 0:
                            ShowMainMenu();
                            break;
                        default:
                            Console.WriteLine("Wrong choice!");
                            break;
                    }
                }
                catch (Exception c) { Console.WriteLine(c.Message); Console.ReadKey(); }
            }
        }

        private void VacansySearch()
        {
            Console.WriteLine("Word for search: ");
            foreach (var item in vacansyService.Search(Console.ReadLine()))
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void AddVacansy()
        {
            try
            {
                string Name = @"^[A-Z]{1}[a-z]{1,}";
                string Category = @"^[A-Z]{1}[a-z]{1,}";
                string Salary = @"^[0-9]{7}";
                Regex regex = new Regex(Name);
                Regex regex1 = new Regex(Category);
                Regex regex2 = new Regex(Salary);
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Salary: ");
                double salary = double.Parse(Console.ReadLine());
                Console.WriteLine("Category: ");
                string category = Console.ReadLine();
                if (!(regex.IsMatch(name)))
                {
                    Console.WriteLine("Name no varified. Try again");
                    throw new Exception();
                }
                if (!(regex2.IsMatch(salary.ToString())))
                {
                    Console.WriteLine("Salary no varified. Try again");
                    throw new Exception();
                }
            
                if (!(regex1.IsMatch(category)))
                {
                    Console.WriteLine("Category no varified. Try again");
                    throw new Exception();
                }
            else { vacansyService.AddVacancy(category, name, salary); }
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong enter!");
                Console.ReadKey();
            }
        }

        private void RemoveVacansy()
        {
            var vacansy = GetVacancy();

            if (vacansy != null)
            {
                vacansyService.DeleteVacansy(vacansy);
            }
        }

        private void EditVacansy()
        {
            var vacansy = GetVacancy();

            if (vacansy != null)
            {
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Salary: ");
                double salary = double.Parse(Console.ReadLine());
                Console.WriteLine("Category: ");
                string category = Console.ReadLine();

                vacansyService.EditVacansy(vacansy, category, name, salary);
            }
        }

        private void GetVacansyInfo()
        {
            var vacansy = GetVacancy();

            if (vacansy != null)
            {
                Console.WriteLine(vacansy.ToString());
            }
        }

        private void GetSortedVacansysList()
        {
            foreach (var item in vacansyService.GetSortedList())
            {
                Console.WriteLine(item.ToString() + '\n');
            }
        }


        private Customer GetCustomer()
        {
            try
            {
                Console.WriteLine("Choose customer: ");
                var customers = customerService.GetCustomers();
                for (int i = 0; i < customers.Count; i++)
                {
                    Console.WriteLine(i + ". " + customers[i].ToString());
                }
                int choice = int.Parse(Console.ReadLine());
                return customerService.GetCustomers().ElementAt(choice);
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong choice!");
                Console.ReadKey();
                return null;
            }
        }

        private Resume GetResume()
        {
            try
            {
                Console.WriteLine("Choose resume: ");
                var resumes = resumeService.GetResumes();
                for (int i = 0; i < resumes.Count; i++)
                {
                    Console.WriteLine(i + ". " + resumes[i].ToString());
                }
                int choice = int.Parse(Console.ReadLine());
                return resumeService.GetResumes().ElementAt(choice);
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong choice!");
                Console.ReadKey();
                return null;
            }
        }

        private Unemployed GetUnemployed()
        {
            try
            {
                Console.WriteLine("Choose unemployed: ");
                var unemployeds = unemployedservice.GetUnemployeds();
                for (int i = 0; i < unemployeds.Count; i++)
                {
                    Console.WriteLine(i + ". " + unemployeds[i].ToString());
                }
                int choice = int.Parse(Console.ReadLine());
                return unemployedservice.GetUnemployeds().ElementAt(choice);
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong choice!");
                Console.ReadKey();
                return null;
            }
        }

        private Vacancy GetVacancy()
        {
            try
            {
                Console.WriteLine("Choose vacansy: ");
                var vacansies = vacansyService.GetVacancies();
                for (int i = 0; i < vacansies.Count; i++)
                {
                    Console.WriteLine(i + ". " + vacansies[i].ToString());
                }
                int choice = int.Parse(Console.ReadLine());
                return vacansyService.GetVacancies().ElementAt(choice);
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong choice!");
                Console.ReadKey();
                return null;
            }
        }
    }
}
