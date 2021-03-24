using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Muljin.Common.Tests
{
    public class StringBuilderExtensionTests
    {

        [Test]
        public void GivenNothingDoesNothing()
        {
            var sb = new StringBuilder();
            sb.Append("test");

            sb.AppendNoneEmpty(", ");

            Assert.AreEqual("test", sb.ToString());
        }

        [Test]
        public void GivenEmptySeperatorJoins()
        {
            var sb = new StringBuilder();
            sb.AppendNoneEmpty("", "Test1", "Test2", "Test3 ", "Test4");
            Assert.AreEqual("Test1Test2Test3 Test4", sb.ToString());
        }

        [Test]
        public void GivenSeperatorAndNoneDoesNothing()
        {
            var sb = new StringBuilder();
            var sb2 = new StringBuilder();

            sb.Append("Test");
            
            sb.AppendNoneEmpty(", ");
            sb2.AppendNoneEmpty(", ");

            Assert.AreEqual("Test", sb.ToString());
            Assert.AreEqual("", sb2.ToString());
        }

        [Test]
        public void GivenSeperatorAndEmptyDoesNothing()
        {
            var sb = new StringBuilder();
            var sb2 = new StringBuilder();

            sb.Append("Test");

            sb.AppendNoneEmpty(", ", "", " ", "   ");
            sb2.AppendNoneEmpty(", ", "", " ", "    ");

            Assert.AreEqual("Test", sb.ToString());
            Assert.AreEqual("", sb2.ToString());
        }

        [Test]
        public void GivenSeperatorAndItemsCorrectlyJoins()
        {
            var sb = new StringBuilder();
            var sb2 = new StringBuilder();

            sb.Append("Test");

            sb.AppendNoneEmpty(", ", "Test1", "Test2", "Test3");
            sb2.AppendNoneEmpty(", ", "Test1", "Test2", "Test3");

            Assert.AreEqual("TestTest1, Test2, Test3", sb.ToString());
            Assert.AreEqual("Test1, Test2, Test3", sb2.ToString());
        }
    }
}
