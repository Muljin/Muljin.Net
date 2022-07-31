using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muljin.Utils;

namespace Muljin.Common.Tests.GuardsTests
{
    public class AlphaNumericGuardsTests
    {
        [TestCase("0")]
        [TestCase("a")]
        [TestCase("01234567890")]
        [TestCase("ABCaabz1234567890")]
        [TestCase("AAAAA")]
        [TestCase("zzzzzz")]
        [TestCase("zzzXzz000")]
        [TestCase("1223zzzzzz000")]
        [TestCase("1223zzzzzz000AHahahans8123nqs8d7bhaia")]
        public void WhenAlphaNumericSucceeds(string value)
        {
            Assert.DoesNotThrow(()=>Guards.AlphaNumeric(value, nameof(value)));
        }

        [TestCase("01234567890#")]
        [TestCase("ABCaabz12'34567890")]
        [TestCase("AAA AA")]
        [TestCase("zzz@zzz")]
        public void WhenNotAlphaNumericFails(string value)
        {
            Assert.Throws<ArgumentException>(()=>Guards.AlphaNumeric(value, nameof(value)));
        }

        [TestCase("01234567890")]
        [TestCase("0")]
        public void WhenNumericSucceeds(string value)
        {
            Assert.DoesNotThrow(() => Guards.Numeric(value, nameof(value)));
        }

        [TestCase("01234567890#")]
        [TestCase("34567890a")]
        [TestCase("82823 8213182")]
        [TestCase("098127x8128")]
        public void WhenNotNumericFails(string value)
        {
            Assert.Throws<ArgumentException>(() => Guards.Numeric(value, nameof(value)));
        }


    }
}
