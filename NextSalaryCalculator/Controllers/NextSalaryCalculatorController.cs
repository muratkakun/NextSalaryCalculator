using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NextSalaryCalculator;
using System.Web.Http;

namespace NextSalaryCalculator.Controllers
{
    public class NextSalaryCalculatorController : ApiController
    {
        //"dto":{"Day":2,"Week":0,"CurrentDate":"3.07.2017","PaymentFrequency":"FirstXDay"}
        //
        public object Index(SalaryDateCalculationDTO dto)
        {
            PaymentDateCalculator calculator = new PaymentDateCalculator();
            return calculator.CalculateNextSalaryDate(dto);
        }

    }
}
