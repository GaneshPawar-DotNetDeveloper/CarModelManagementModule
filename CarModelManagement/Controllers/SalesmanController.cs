using CarModelManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarModelManagement.Controllers
{
    public class SalesmanController : Controller
    {
        private readonly SalesmanRepository _repository = new SalesmanRepository();

        public ActionResult CommissionReport(int salesmanId)
        {
            var salesman = _repository.GetSalesmen().Find(s => s.Id == salesmanId);
            var sales = _repository.GetSalesBySalesman(salesmanId);

            decimal totalCommission = 0;
            foreach (var sale in sales)
            {
                var commissionRate = _repository.GetCommissionRate(sale.Brand, sale.Class);
                if (commissionRate != null)
                {
                    decimal commission = commissionRate.FixedCommission;
                    if (sale.Class == "A" && salesman.LastYearSalesAmount > 500000)
                    {
                        commission += sale.NumberOfCarsSold * (commissionRate.PercentageRate / 100 + 2);
                    }
                    else
                    {
                        commission += sale.NumberOfCarsSold * (commissionRate.PercentageRate / 100);
                    }
                    totalCommission += commission;
                }
            }

            ViewBag.SalesmanName = salesman.Name;
            ViewBag.TotalCommission = totalCommission;

            return View(sales);
        }
    }
}