using Accounting.DataLayer.Context;
using Accounting.ViewModels.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Business
{
    public class Account
    {
        public static ReportViewModel ReportFormMain()
        {
            ReportViewModel rp = new ReportViewModel();
            using (UnitOfWork db = new UnitOfWork())
            {
                DateTime startdate = new DateTime(DateTime.Now.Year , DateTime.Now.Month , 01);
                DateTime enddate = new DateTime(DateTime.Now.Year , DateTime.Now.Month , 30);
                var Recive = db.AccountingRepository.Get(x => x.TypeID == 1 && x.DateTilte >= startdate && x.DateTilte <= enddate).Select(x=>x.Amount).ToList();
                var Pay = db.AccountingRepository.Get(x => x.TypeID == 2 && x.DateTilte >= startdate && x.DateTilte <= enddate).Select(x => x.Amount).ToList();
                rp.Recive = Recive.Sum();
                rp.Pay = Pay.Sum();
                rp.AccountBalance = (Recive.Sum() - Pay.Sum());
            }
            return rp;
        }


    }
}
