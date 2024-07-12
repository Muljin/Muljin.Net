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

        [TestCase("1234", 4, 5, false)]
        [TestCase("1234 ", 4, 5, false)]
        [TestCase("1234", 4, 5, true)]
        [TestCase("1234 ", 4, 5, true)]
        [TestCase("1234    ", 4, 5, false)]
        [TestCase("    1234    ", 4, 5, false)]
        public void WhenStringLengthCorrectSucceeds(string value, int min, int max, bool allowWhiteSpace){
            Assert.DoesNotThrow(()=>Guards.Length(value,min, max, allowWhiteSpace));
        }

        [TestCase("1234", 1, 3, false)]
        [TestCase("123 ", 1, 3, true)]
        [TestCase("12323", 1, 3, true)]
        [TestCase("12323", 1, 3, false)]
        [TestCase(" 123", 1, 3, true)]
        [TestCase(" 1232 ", 1, 3, true)]
        [TestCase("  ", 1, 3, false)]
        public void WhenStringLengthWrongFails(string value, int min, int max, bool allowWhiteSpace){
            Assert.Throws<ArgumentException>(()=>Guards.Length(value,min, max, allowWhiteSpace));
        }

        [TestCase(null, 1, 3, false)]
        public void WhenStringNullOrWhitespaceFails(string value, int min, int max, bool allowWhiteSpace){
            Assert.Throws<ArgumentNullException>(()=>Guards.Length(value,min, max, allowWhiteSpace));
        }

        [TestCase("ABC")]
        [TestCase("ABc")]
        [TestCase("aZAz")]
        [TestCase("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        public void WhenLatinSucceeds(string value){
            Assert.DoesNotThrow(()=>Guards.LatinOnly(value));

        }

        [TestCase("ABC ")]
        [TestCase("ABc1")]
        [TestCase("aZAz,")]
        [TestCase("غا")]
        [TestCase("123")]
        public void WhenNotLatinFails(string value){
            Assert.Throws<ArgumentException>(()=>Guards.LatinOnly(value));
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

        [Test()]
        public void WhenGuidEqual_ThrowsException()
        {
            //arrange
            var guid = Guid.NewGuid();
            var guid2 = Guid.Parse(guid.ToString());

            //act and assert
            Assert.Throws<ArgumentException>(()=>Guards.NotEqual(guid, guid2));
        }

        [Test()]
        public void WhenStringEqual_ThrowsException()
        {
            Assert.Throws<ArgumentException>(()=>Guards.NotEqual("val1", "val1"));
        }

        [TestCase("val1", "val2")]
        [TestCase("", " ")]
        [TestCase("", ".")]
        public void WhenStringNotEqual_DoesNotThrowException(string val1, string val2)
        {
            Assert.DoesNotThrow(()=>Guards.NotEqual(val1, val2));
        }


    }
}
