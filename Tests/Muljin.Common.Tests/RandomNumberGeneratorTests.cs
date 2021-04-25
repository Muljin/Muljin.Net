using Muljin.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Muljin.Common.Tests
{
    public class RandomNumberGeneratorTests
    {

        [Test]
        public void NumbersStayBetweenMaxAndMin()
        {
            int max = 874749;
            int min = -2323;
            using (var rn = new RandomNumberGenerator())
            {
                for(var i = 0; i<1000; i++)
                {
                    var a = rn.Generate(max,min);
                    Assert.LessOrEqual(a, max);
                    Assert.GreaterOrEqual(a, min);
                }
            }
        }

        [Test]
        public void RandomnessDistributionShouldBeEqual()
        {
            int max = 874749;
            int min = -2323;

            decimal runningAvg = 0;

            using (var rn = new RandomNumberGenerator())
            {
                for (var i = 1; i < 100000; i++)
                {
                    var a = rn.Generate(max, min);
                    runningAvg += (a - runningAvg) / i;
                }
            }

            var avg = (max + min) / 2m;

            Assert.IsTrue(Math.Abs(runningAvg - avg) < (avg * 0.05m));

        }
    }
}
