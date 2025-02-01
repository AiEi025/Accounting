﻿using Accounting.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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
            try
            {
                db.Entry(customer).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
