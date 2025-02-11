using Accounting.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Accounting.ViewModels.Customers;

namespace Accounting.DataLayer.Services
{
    public class CustomerRepository : ICustomerRepository
    {

        private Accounting_DBEntities1 db;
        public CustomerRepository(Accounting_DBEntities1 context)
        {
            db = context;
        }

        public bool DeleteCustomer(Customers customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            var customer = GetCustomersById(customerId);
            DeleteCustomer(customer);
            return true;
        }

        public List<Customers> GetAllCustomers() { return db.Customers.ToList(); }

        public int GetCustomerIdByName(string name)
        {
            return db.Customers.First(x => x.FullName == name).CustomerID;
        }

        public IEnumerable<Customers> GetCustomersByFilter(string parameter)
        {
            return db.Customers.Where(x => x.FullName.ToLower().Contains(parameter) ||
                                           x.Mobile.Contains(parameter) ||
                                           x.Email.ToLower().Contains(parameter)).ToList();
        }



        public Customers GetCustomersById(int customerId)
        {
            return db.Customers.Find(customerId);
        }

        public List<ListCustomerViewModel> GetNameCustomers(string filter = "")
        {
            if (filter == "")
            {
                return db.Customers.Select(x => new ListCustomerViewModel() { CustomerID = x.CustomerID, FullName = x.FullName }).ToList();
            }
            else
                return db.Customers.Where(x => x.FullName.Contains(filter)).Select(x => new ListCustomerViewModel() { CustomerID = x.CustomerID, FullName = x.FullName }).ToList();
        }

        public bool InsertCustomer(Customers customer)
        {
            try
            {
                db.Customers.Add(customer);
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }



        public bool UpdateCustomer(Customers customer)
        {

            var LOCAL = db.Set<Customers>()
            .Local
            .FirstOrDefault(f => f.CustomerID == customer.CustomerID);
            if (LOCAL != null)
            {
                db.Entry(LOCAL).State = EntityState.Detached;
            }
            db.Entry(customer).State = EntityState.Modified;
            return true;

        }




    }
}
