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

            Assert.AreEqual(string.Empty, res);
            Assert.IsNull(res2);
        }

        [Test]
        public void GivenAllSmallDoesNothing()
        {
            var res = StringUtils.ConvertToSnakeCase("hellothere");
            var res2 = StringUtils.ConvertToSnakeCase("hi");
            var res3 = StringUtils.ConvertToSnakeCase("m");


            Assert.AreEqual("hellothere", res);
            Assert.AreEqual("hi", res2);
            Assert.AreEqual("m", res3);
        }

        [Test]
        public void GivenLowerCaseCovnerts()
        {
            var res = StringUtils.ConvertToSnakeCase("helloThere");
            var res2 = StringUtils.ConvertToSnakeCase("hiThereHowAreYouToday");

            Assert.AreEqual("hello_there", res);
            Assert.AreEqual("hi_there_how_are_you_today", res2);
        }

        [Test]
        public void GivenUpperCaseConverts()
        {
            var res = StringUtils.ConvertToSnakeCase("HelloThere");
            var res2 = StringUtils.ConvertToSnakeCase("HiThereHowAreYouToday");
            var res3 = StringUtils.ConvertToSnakeCase("HHHLLL");

            Assert.AreEqual("hello_there", res);
            Assert.AreEqual("hi_there_how_are_you_today", res2);
            Assert.AreEqual("h_h_h_l_l_l", res3);
        }

    }
}
