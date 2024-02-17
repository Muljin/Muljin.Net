using Muljin.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Muljin.Common.Tests
{
    public class StringUtilsTests
    {
        [Test]
        public void GivenEmptyStringReturnsEmpty()
        {
            var res = StringUtils.ConvertToSnakeCase(string.Empty);
            var res2 = StringUtils.ConvertToSnakeCase(null);

            Assert.That(res, Is.Empty);
            Assert.That(res2, Is.Null);
        }

        [Test]
        public void GivenAllSmallDoesNothing()
        {
            var res = StringUtils.ConvertToSnakeCase("hellothere");
            var res2 = StringUtils.ConvertToSnakeCase("hi");
            var res3 = StringUtils.ConvertToSnakeCase("m");


            Assert.That(res, Is.EqualTo("hellothere"));
            Assert.That(res2, Is.EqualTo("hi"));
            Assert.That(res3, Is.EqualTo("m"));
        }

        [Test]
        public void GivenLowerCaseCovnerts()
        {
            var res = StringUtils.ConvertToSnakeCase("helloThere");
            var res2 = StringUtils.ConvertToSnakeCase("hiThereHowAreYouToday");

            Assert.That(res, Is.EqualTo("hello_there"));
            Assert.That(res2, Is.EqualTo("hi_there_how_are_you_today"));
        }

        [Test]
        public void GivenUpperCaseConverts()
        {
            var res = StringUtils.ConvertToSnakeCase("HelloThere");
            var res2 = StringUtils.ConvertToSnakeCase("HiThereHowAreYouToday");
            var res3 = StringUtils.ConvertToSnakeCase("HHHLLL");

            Assert.That(res, Is.EqualTo("hello_there"));
            Assert.That(res2, Is.EqualTo("hi_there_how_are_you_today"));
            Assert.That(res3, Is.EqualTo("h_h_h_l_l_l"));
        }

        
        [TestCase("", ExpectedResult = "")]
        [TestCase((string)null, ExpectedResult = (string)null)]
        public string WhenGivenEmptyStringStringLimitReturnsEmpty(string input)
        {
            return StringUtils.LimitString(input, 10);
        }

        [TestCase("blahblah", ExpectedResult = "blahblah")]
        [TestCase("1234567890", ExpectedResult = "1234567890")]
        [TestCase("aA", ExpectedResult = "aA")]
        public string WhenGivenNonEmptyStringBelowLimitReturnsSame(string input)
        {
            return StringUtils.LimitString(input, 10);
        }


        [TestCase("blahblahblah", ExpectedResult = "blahblahbl")]
        [TestCase("blahblahblahblahblahblahblahblahblahblah", ExpectedResult = "blahblahbl")]
        public string WhenGivenLongerStringReturnsSubstring(string input)
        {
            return StringUtils.LimitString(input, 10);
        }

    }
}
