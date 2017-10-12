using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfSampleProj.UI.Extensions;

namespace WPFSampleProj.Tests.Extensions
{
    [TestClass]
    public class DateTimeExtensionTests
    {
        [TestMethod]
        public void DateTimeExtensionTests_Sunday_StartOfWeekTest()
        {
            var Actual = new DateTime(2017, 10, 10);

            var Expected = new DateTime(2017, 10, 08);


            Assert.AreEqual(Actual.StartOfWeek(DayOfWeek.Sunday), Expected);

        }

        [TestMethod]
        public void DateTimeExtensionTests_Monday_StartOfWeekTest()
        {
            var Actual = new DateTime(2017, 10, 10);

            var Expected = new DateTime(2017, 10, 09);


            Assert.AreEqual(Actual.StartOfWeek(DayOfWeek.Monday), Expected);

        }

        [TestMethod]
        public void DateTimeExtensionTests_Tuesday_StartOfWeekTest()
        {
            var Actual = new DateTime(2017, 10, 10);

            var Expected = new DateTime(2017, 10, 10);


            Assert.AreEqual(Actual.StartOfWeek(DayOfWeek.Tuesday), Expected);

        }

        [TestMethod]
        public void DateTimeExtensionTests_WednesDay_StartOfWeekTest()
        {
            var Actual = new DateTime(2017, 10, 10);

            var Expected = new DateTime(2017, 10, 11);


            Assert.AreEqual(Actual.StartOfWeek(DayOfWeek.Wednesday), Expected);

        }


        [TestMethod]
        public void DateTimeExtensionTests_Thursday_StartOfWeekTest()
        {
            var Actual = new DateTime(2017, 10, 10);

            var Expected = new DateTime(2017, 10, 12);


            Assert.AreEqual(Actual.StartOfWeek(DayOfWeek.Thursday), Expected);

        }


        [TestMethod]
        public void DateTimeExtensionTests_Friday_StartOfWeekTest()
        {
            var Actual = new DateTime(2017, 10, 10);

            var Expected = new DateTime(2017, 10, 13);


            Assert.AreEqual(Actual.StartOfWeek(DayOfWeek.Thursday), Expected);

        }


        [TestMethod]
        public void DateTimeExtensionTests_Saturday_StartOfWeekTest()
        {
            var Actual = new DateTime(2017, 10, 10);

            var Expected = new DateTime(2017, 10, 14);


            Assert.AreEqual(Actual.StartOfWeek(DayOfWeek.Saturday), Expected);

        }

        [TestInitialize]
        void Setup()
        {

        }



    }
}
