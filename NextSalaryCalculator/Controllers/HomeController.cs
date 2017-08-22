using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NextSalaryCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string Get(SalaryDateCalculationDTO dto)
        {
            PaymentDateCalculator calculator = new PaymentDateCalculator();
            return calculator.CalculateNextSalaryDate(dto).ToString();
        }

        public object Index2(SalaryDateCalculationDTO dto)
        {
            PaymentDateCalculator calculator = new PaymentDateCalculator();
            return calculator.CalculateNextSalaryDate(dto);
        }
    }
}
