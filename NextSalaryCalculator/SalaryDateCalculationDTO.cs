﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NextSalaryCalculator
{
 
    /// <summary>
    /// Next Salary Calculator Parameter Class
    /// </summary>
    public class SalaryDateCalculationDTO
    {
        /// <summary>
        /// Day parameter
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// Week parameter
        /// </summary>
        public int Week { get; set; }
        /// <summary>
        ///SpecificDayofMonth: nth day of month.
        ///LastWorkingDayofMonth: last working day of month
        ///DayBeforeLastWorkingDay: day before last working day of month
        ///FirstWorkingdayofMonth: first working day of month
        ///FirstXDay: first x day of month. ie. if day is 2, it means first tuesday of month
        ///LastXDay: last x day of month. ie. if day is 1, it means last monday of month
        ///NthXDay: nth x day of month. ie. if week is 2 and day is 4, it means second thursday of the month. Week property is used to specify which nth thursday day of month. Not nth week!
        ///NthWeeksXDay: x day of nth week of month. ie. if week is 1 and day is 3, it means wednesday of first week of the month. Week property is used to specify the nth week
        /// </summary>
        public SalaryFrequency PaymentFrequency { get; set; }

        /// <summary>
        /// CurrentDate parameter
        /// </summary>
        public DateTime CurrentDate { get; set; }
    }
}