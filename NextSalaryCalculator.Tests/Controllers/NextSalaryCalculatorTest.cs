using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NextSalaryCalculator;
using NextSalaryCalculator.Controllers;

namespace NextSalaryCalculator.Tests.Controllers
{
    /// <summary>
    /// Summary description for NextSalaryCalculatorTest
    /// </summary>
    [TestClass]
    public class NextSalaryCalculatorTest
    {
        public NextSalaryCalculatorTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void SpecificDayofMonth_TestMethod()
        {
            HomeController nextSalary = new HomeController();

            SalaryDateCalculationDTO dto = new SalaryDateCalculationDTO();
            dto.CurrentDate = new DateTime(2017, 7, 8);
            dto.PaymentFrequency = SalaryFrequency.SpecificDayofMonth;
            dto.Day = 12;
            dto.Week = 0;

            string dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("12.07.2017", dateResult);

            //Test Value 2
            dto.CurrentDate = new DateTime(2017, 7, 20);
            dto.PaymentFrequency = SalaryFrequency.SpecificDayofMonth;
            dto.Day = 14;
            dto.Week = 0;

            dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");

            // Assert
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("14.08.2017", dateResult);


        }
        [TestMethod]
        public void LastWorkingDayofMonth_TestMethod()
        {
            HomeController nextSalary = new HomeController();

            SalaryDateCalculationDTO dto = new SalaryDateCalculationDTO();
            dto.CurrentDate = new DateTime(2017, 6, 8);
            dto.PaymentFrequency = SalaryFrequency.LastWorkingDayofMonth;
            dto.Day = 0;
            dto.Week = 0;

            string dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("30.06.2017", dateResult);

            //Test Value 2
            dto.CurrentDate = new DateTime(2017, 9, 20);
            dto.PaymentFrequency = SalaryFrequency.LastWorkingDayofMonth;
            dto.Day = 0;
            dto.Week = 0;

            dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");

            // Assert
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("29.09.2017", dateResult);


        }
        [TestMethod]
        public void DayBeforeLastWorkingDay_TestMethod()
        {
            HomeController nextSalary = new HomeController();

            SalaryDateCalculationDTO dto = new SalaryDateCalculationDTO();
            dto.CurrentDate = new DateTime(2017, 6, 8);
            dto.PaymentFrequency = SalaryFrequency.DayBeforeLastWorkingDay;
            dto.Day = 0;
            dto.Week = 0;

            string dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("29.06.2017", dateResult);

            //Test Value 2
            dto.CurrentDate = new DateTime(2017, 9, 20);
            dto.PaymentFrequency = SalaryFrequency.DayBeforeLastWorkingDay;
            dto.Day = 0;
            dto.Week = 0;

            dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");

            // Assert
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("28.09.2017", dateResult);


        }
        [TestMethod]
        public void FirstWorkingdayofMonth_TestMethod()
        {
            HomeController nextSalary = new HomeController();

            SalaryDateCalculationDTO dto = new SalaryDateCalculationDTO();
            dto.CurrentDate = new DateTime(2017, 6, 8);
            dto.PaymentFrequency = SalaryFrequency.FirstWorkingdayofMonth;
            dto.Day = 0;
            dto.Week = 0;

            string dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("03.07.2017", dateResult);

            //Test Value 2
            dto.CurrentDate = new DateTime(2017, 10, 1);
            dto.PaymentFrequency = SalaryFrequency.FirstWorkingdayofMonth;
            dto.Day = 0;
            dto.Week = 0;

            dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("02.10.2017", dateResult);

            //Test Value 3
            dto.CurrentDate = new DateTime(2017, 8, 1);
            dto.PaymentFrequency = SalaryFrequency.FirstWorkingdayofMonth;
            dto.Day = 0;
            dto.Week = 0;

            dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("01.08.2017", dateResult);


        }
        [TestMethod]
        public void FirstXDay_TestMethod()
        {
            HomeController nextSalary = new HomeController();

            SalaryDateCalculationDTO dto = new SalaryDateCalculationDTO();
            dto.CurrentDate = new DateTime(2017, 7, 3);
            dto.PaymentFrequency = SalaryFrequency.FirstXDay;
            dto.Day = 2;
            dto.Week = 0;

            string dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("04.07.2017", dateResult);

            //Test Value 2
            dto.CurrentDate = new DateTime(2017, 7, 6);
            dto.PaymentFrequency = SalaryFrequency.FirstXDay;
            dto.Day = 2;
            dto.Week = 0;

            dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("01.08.2017", dateResult);

            //Test Value 3
            dto.CurrentDate = new DateTime(2017, 7, 1);
            dto.PaymentFrequency = SalaryFrequency.FirstXDay;
            dto.Day = 4;
            dto.Week = 0;

            dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("06.07.2017", dateResult);

        }

        [TestMethod]
        public void LastXDay_TestMethod()
        {
            HomeController nextSalary = new HomeController();

            SalaryDateCalculationDTO dto = new SalaryDateCalculationDTO();


            //Test Value 1
            dto = new SalaryDateCalculationDTO();
            dto.CurrentDate = new DateTime(2017, 7, 14);
            dto.PaymentFrequency = SalaryFrequency.LastXDay;
            dto.Day = 3;
            dto.Week = 0;

            string dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("26.07.2017", dateResult);

            //Test Value 2
            dto.CurrentDate = new DateTime(2017, 8, 18);
            dto.PaymentFrequency = SalaryFrequency.LastXDay;
            dto.Day = 1;
            dto.Week = 0;

            dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("28.08.2017", dateResult);

            //Test Value 3
            dto.CurrentDate = new DateTime(2017, 9, 21);
            dto.PaymentFrequency = SalaryFrequency.LastXDay;
            dto.Day = 5;
            dto.Week = 0;

            dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("29.09.2017", dateResult);

        }

        [TestMethod]
        public void NthXDay_TestMethod()
        {
            HomeController nextSalary = new HomeController();

            SalaryDateCalculationDTO dto = new SalaryDateCalculationDTO();
            dto.CurrentDate = new DateTime(2017, 6, 5);
            dto.PaymentFrequency = SalaryFrequency.NthXDay;
            dto.Day = 1;
            dto.Week = 1;

            string dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("03.07.2017", dateResult);

            //Test Value 2
            dto.CurrentDate = new DateTime(2017, 7, 8);
            dto.PaymentFrequency = SalaryFrequency.NthXDay;
            dto.Day = 3;
            dto.Week = 3;

            dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("19.07.2017", dateResult);

            //Test Value 3
            dto.CurrentDate = new DateTime(2017, 6, 14);
            dto.PaymentFrequency = SalaryFrequency.NthXDay;
            dto.Day = 5;
            dto.Week = 5;

            dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("30.06.2017", dateResult);


        }

        [TestMethod]
        public void NthWeeksXDay_TestMethod()
        {
            HomeController nextSalary = new HomeController();

            SalaryDateCalculationDTO dto = new SalaryDateCalculationDTO();
            dto.CurrentDate = new DateTime(2017, 8, 10);
            dto.PaymentFrequency = SalaryFrequency.NthWeeksXDay;
            dto.Day = 1;
            dto.Week = 1;

            object dateResultEx = nextSalary.Index2(dto);
            Assert.IsInstanceOfType(dateResultEx, typeof(NextSalaryCalculator.PaymentDateCalculator.NoSuchDateException));


            //Test Value 2
            dto.CurrentDate = new DateTime(2017, 7, 8);
            dto.PaymentFrequency = SalaryFrequency.NthWeeksXDay;
            dto.Day = 3;
            dto.Week = 3;

            object dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("12.07.2017", dateResult);

            //Test Value 3
            dto.CurrentDate = new DateTime(2017, 6, 14);
            dto.PaymentFrequency = SalaryFrequency.NthWeeksXDay;
            dto.Day = 5;
            dto.Week = 5;

            dateResult = ((DateTime)nextSalary.Index2(dto)).ToString("dd.MM.yyyy");
            Assert.IsNotNull(dateResult);
            Assert.AreEqual("30.06.2017", dateResult);


        }
    }
}
