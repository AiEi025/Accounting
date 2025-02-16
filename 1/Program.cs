using Accounting.DataLayer;
using Accounting.DataLayer.Context;
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
        public class sell :MyClass
        { 
        
        }
        //دیگر نمی توان از ان ازث بری کرد
        public sealed class QSESQ
        {
        
        }
        public abstract class MyClass
        {
            public void qwerewq()
            {
                Console.WriteLine("سلام بر استاد اعظم");
            }
        }
        static void Main(string[] args)
        {
            sell cell = new sell();
            cell.qwerewq();
            
            Class2 class2 = new Class2();

            class2.MySoul();

            Console.ReadLine();

            ////constructor indection
            //Accounting_DBEntities1 db = new Accounting_DBEntities1();
            //ICustomerRepository customer = new CustomerRepository(db);
            //Customers AddCustomer = new Customers() { FullName = "salam", Address = "pirouzu", Mobile = "09123135097", Email = "@gmail.com", CustomerImage = "No Photoes" };

            //var x = customer.InsertCustomer(AddCustomer);
            //var list = customer.GetAllCustomers();

            //customer.save();


            //____________________________________________________________


            //Best practise ::


            //UnitOfWork unitOfWork = new UnitOfWork();
            //unitOfWork.CustomerRepository.GetAllCustomers();
            //unitOfWork.Dispose();
            //Accounting_DBEntities1 dBEntities1 = new Accounting_DBEntities1();





        }
    }
}
