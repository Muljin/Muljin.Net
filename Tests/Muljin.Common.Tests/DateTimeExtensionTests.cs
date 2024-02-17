using System;
using NUnit.Framework;

namespace Muljin.Common.Tests
{
    public class DateTimeExtensionTests
    {


        [Test]
        public void Given_DateTime_Returns_Epoch_Seconds()
        {
            //arrange
            var d1 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var d2 = new DateTime(2000, 6, 1, 8, 0, 0, DateTimeKind.Utc);
            var d3 = new DateTime(2010, 12, 1, 16, 0, 0, DateTimeKind.Utc);
            var d4 = new DateTime(2020, 12, 31, 23, 59, 59, DateTimeKind.Utc);

            //act
            var e1 = d1.ToEpoch();
            var e2 = d2.ToEpoch();
            var e3 = d3.ToEpoch();
            var e4 = d4.ToEpoch();

            //asset
            Assert.That(e1, Is.EqualTo(0));
            Assert.That(e2, Is.EqualTo(959846400));
            Assert.That(e3, Is.EqualTo(1291219200));
            Assert.That(e4, Is.EqualTo(1609459199));
        }

        [Test]
        public void Given_Epoch_Seconds_Returns_DateTime()
        {
            

            //arrange
            var d1 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var d2 = new DateTime(2000, 6, 1, 8, 0, 0, DateTimeKind.Utc);
            var d3 = new DateTime(2010, 12, 1, 16, 0, 0, DateTimeKind.Utc);
            var d4 = new DateTime(2020, 12, 31, 23, 59, 59, DateTimeKind.Utc);

            //act
            var e1 = DateTimeExtensions.EpochToDateTime(0);
            var e2 = DateTimeExtensions.EpochToDateTime(959846400);
            var e3 = DateTimeExtensions.EpochToDateTime(1291219200);
            var e4 = DateTimeExtensions.EpochToDateTime(1609459199);

            //asset
            Assert.That(e1, Is.EqualTo(d1));
            Assert.That(e2, Is.EqualTo(d2));
            Assert.That(e3, Is.EqualTo(d3));
            Assert.That(e4, Is.EqualTo(d4));
        }
    }
}