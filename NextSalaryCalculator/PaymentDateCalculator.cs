using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Web;

namespace NextSalaryCalculator
{
    public class PaymentDateCalculator : IPaymentDateCalculator
    {

        SalaryDateCalculationDTO salaryDateCalculationDTO;

        private DateTime GetLastBusinessOfDate(DateTime date)
        {
            while (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
            {
                date = date.AddDays(-1);
            }

            return date;
        }

        private DateTime GetFirstXDayOfMonth(DateTime date, int day)
        {
            DateTime newdate = new DateTime(date.Year, date.Month, 1);

            while ((int)newdate.DayOfWeek != day)
            {
                newdate = newdate.AddDays(1);
            }

            return newdate;
        }

        private DateTime GetLastXDayOfMonth(DateTime date, int day)
        {
            DateTime LastOfMonth = new DateTime(date.Year, date.Month,
                DateTime.DaysInMonth(date.Year, date.Month));


            while ((int)LastOfMonth.DayOfWeek != day)
            {
                LastOfMonth = LastOfMonth.AddDays(-1);
            }

            return LastOfMonth;
        }

        private DateTime GetLastOfMonth(DateTime date)
        {
            DateTime LastOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            return LastOfMonth;
        }
        private DateTime GetFirstBusinessOfDate(DateTime date)
        {
            while (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
            {
                date = date.AddDays(1);
            }

            return date;
        }

        private DateTime SpecificDayofMonth()
        {
            DateTime result = (salaryDateCalculationDTO.CurrentDate.Day > salaryDateCalculationDTO.Day) ? (new DateTime(salaryDateCalculationDTO.CurrentDate.AddYears(
                    salaryDateCalculationDTO.CurrentDate.AddMonths(1).Year - salaryDateCalculationDTO.CurrentDate.Year).Year,
                    salaryDateCalculationDTO.CurrentDate.AddMonths(1).Month,
                    salaryDateCalculationDTO.Day)) : new DateTime(salaryDateCalculationDTO.CurrentDate.Year, salaryDateCalculationDTO.CurrentDate.Month, salaryDateCalculationDTO.Day);
            return result;
        }
        private DateTime LastWorkingDayofMonth()
        {
            DateTime LastOfMonth = new DateTime(salaryDateCalculationDTO.CurrentDate.Year, salaryDateCalculationDTO.CurrentDate.Month,
                DateTime.DaysInMonth(salaryDateCalculationDTO.CurrentDate.Year, salaryDateCalculationDTO.CurrentDate.Month));

            return GetLastBusinessOfDate(LastOfMonth);
        }
        private DateTime DayBeforeLastWorkingDay()
        {
            DateTime LastOfMonth = new DateTime(salaryDateCalculationDTO.CurrentDate.Year, salaryDateCalculationDTO.CurrentDate.Month,
                DateTime.DaysInMonth(salaryDateCalculationDTO.CurrentDate.Year, salaryDateCalculationDTO.CurrentDate.Month));

            return GetLastBusinessOfDate(LastOfMonth).AddDays(-1);
        }
        private DateTime FirstWorkingdayofMonth()
        {
            if (salaryDateCalculationDTO.CurrentDate.Day == 1)
                return GetFirstBusinessOfDate(salaryDateCalculationDTO.CurrentDate);

            return GetFirstBusinessOfDate(GetLastOfMonth(salaryDateCalculationDTO.CurrentDate).AddDays(1));
        }
        private DateTime FirstXDay()
        {
            DateTime firstXDayOfThisMonth = GetFirstXDayOfMonth(salaryDateCalculationDTO.CurrentDate, salaryDateCalculationDTO.Day);

            if (salaryDateCalculationDTO.CurrentDate <= firstXDayOfThisMonth)
                return firstXDayOfThisMonth;

            
            firstXDayOfThisMonth = GetFirstXDayOfMonth(salaryDateCalculationDTO.CurrentDate.AddMonths(1), salaryDateCalculationDTO.Day);

            return firstXDayOfThisMonth;
        }
        private DateTime LastXDay()
        {
            return GetLastXDayOfMonth(salaryDateCalculationDTO.CurrentDate, salaryDateCalculationDTO.Day);
        }
        private DateTime NthXDay()
        {
            DateTime nthXdayOfMonth = GetFirstXDayOfMonth(salaryDateCalculationDTO.CurrentDate, salaryDateCalculationDTO.Day).AddDays((salaryDateCalculationDTO.Week - 1) * 7);
            if (nthXdayOfMonth > salaryDateCalculationDTO.CurrentDate)
                return nthXdayOfMonth;

            return GetFirstXDayOfMonth(salaryDateCalculationDTO.CurrentDate.AddMonths(1), salaryDateCalculationDTO.Day).AddDays((salaryDateCalculationDTO.Week - 1) * 7);
        }

        private object NthWeeksXDay()
        {

            DateTime firstDateOfThisMonth = new DateTime(salaryDateCalculationDTO.CurrentDate.Year, salaryDateCalculationDTO.CurrentDate.Month, 1);
            if ((int)firstDateOfThisMonth.DayOfWeek > salaryDateCalculationDTO.Day && salaryDateCalculationDTO.Week == 1)
                return new NoSuchDateException();

            DateTime newDate = firstDateOfThisMonth.AddDays((salaryDateCalculationDTO.Week - 1) * 7);
            int dif = (int)newDate.DayOfWeek - salaryDateCalculationDTO.Day;

            newDate = newDate.AddDays(-1*dif);

            if (newDate.Year != salaryDateCalculationDTO.CurrentDate.Year || newDate.Month != salaryDateCalculationDTO.CurrentDate.Month)
                return new NoSuchDateException();

            return newDate;
        }
        public PaymentDateCalculator()
        {

        }

        public object CalculateNextSalaryDate(SalaryDateCalculationDTO date)
        {
            salaryDateCalculationDTO = date;
            switch (salaryDateCalculationDTO.PaymentFrequency)
            {
                case SalaryFrequency.SpecificDayofMonth:
                    return SpecificDayofMonth();
                case SalaryFrequency.LastWorkingDayofMonth:
                    return LastWorkingDayofMonth();
                case SalaryFrequency.DayBeforeLastWorkingDay:
                    return DayBeforeLastWorkingDay();
                case SalaryFrequency.FirstWorkingdayofMonth:
                    return FirstWorkingdayofMonth();
                case SalaryFrequency.FirstXDay:
                    return FirstXDay();
                case SalaryFrequency.LastXDay:
                    return LastXDay();
                case SalaryFrequency.NthXDay:
                    return NthXDay();
                case SalaryFrequency.NthWeeksXDay:
                    return NthWeeksXDay();
                default:
                    throw new Exception("invalid parameter");
            }
        }

        [Serializable]
        public class NoSuchDateException : System.Exception
        {
            private int exceptionCode;
            public int ExceptionCode
            {
                get
                {
                    return exceptionCode;
                }
                set
                {
                    exceptionCode = value;
                }
            }

            public NoSuchDateException() : base() { }

            public NoSuchDateException(string message) : base(message) { }

            public NoSuchDateException(string message, int exceptionCode)
                : base(message)
            {
                this.exceptionCode = exceptionCode;
            }
        }
    }
}