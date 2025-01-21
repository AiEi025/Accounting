using Accounting.DataLayer;
using Accounting.DataLayer.Repositories;
using Accounting.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository customer = new CustomerRepository();
            Customers AddCustomer = new Customers() {FullName = "salam" , Address = "pirouzu" , Mobile ="09123135097" , Email = "@gmail.com" , CustomerImage = "No Photoes"};
           var x = customer.InsertCustomer(AddCustomer);
            var list = customer.GetAllCustomers();
           
            customer.save();
        }
    }
}
