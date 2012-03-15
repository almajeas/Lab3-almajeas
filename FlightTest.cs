using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{

        private DateTime date1 = new DateTime(2012, 3, 01);
        private DateTime date2 = new DateTime(2012, 3, 11);
        private DateTime dateOne = new DateTime(2012, 3, 2);
        private DateTime dateTwo = new DateTime(2012, 3, 3);

        [Test()]
        public void TestThatFlightlInitializes()
        {
            var target = new Flight(date1, date2 , 3000);
            Assert.IsNotNull(target);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightWrongDatesThrowsONInvalidOperationException()
        {
            new Flight(date2, date1, 3000);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightNegativeMilesThrowsArgumentOutOfRangeException()
        {
            new Flight(date1, date2, -5);
        }


        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDayFlight()
        {
            var target = new Flight(date1, dateOne, 300);
            Assert.AreEqual(200 + ((1) * 20), target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDayFlight()
        {
            var target = new Flight(date1, dateTwo, 300);
            Assert.AreEqual(200 + ((2) * 20), target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDayFlight()
        {
            var target = new Flight(date1, date2, 300);
            Assert.AreEqual(200 + ((10)*20), target.getBasePrice());
        }



	}
}
