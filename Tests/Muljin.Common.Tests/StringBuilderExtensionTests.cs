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

            Assert.That(sb.ToString(), Is.EqualTo("test"));
        }

        [Test]
        public void GivenEmptySeperatorJoins()
        {
            var sb = new StringBuilder();
            sb.AppendNoneEmpty("", "Test1", "Test2", "Test3 ", "Test4");

            Assert.That(sb.ToString(), Is.EqualTo("Test1Test2Test3 Test4"));
        }

        [Test]
        public void GivenSeperatorAndNoneDoesNothing()
        {
            var sb = new StringBuilder();
            var sb2 = new StringBuilder();

            sb.Append("Test");
            
            sb.AppendNoneEmpty(", ");
            sb2.AppendNoneEmpty(", ");

            Assert.That(sb.ToString(), Is.EqualTo("Test"));
            Assert.That(sb2.ToString(), Is.EqualTo(""));
        }

        [Test]
        public void GivenSeperatorAndEmptyDoesNothing()
        {
            var sb = new StringBuilder();
            var sb2 = new StringBuilder();

            sb.Append("Test");

            sb.AppendNoneEmpty(", ", "", " ", "   ");
            sb2.AppendNoneEmpty(", ", "", " ", "    ");

            Assert.That(sb.ToString(), Is.EqualTo("Test"));
            Assert.That(sb2.ToString(), Is.EqualTo(""));
        }

        [Test]
        public void GivenSeperatorAndItemsCorrectlyJoins()
        {
            var sb = new StringBuilder();
            var sb2 = new StringBuilder();

            sb.Append("Test");

            sb.AppendNoneEmpty(", ", "Test1", "Test2", "Test3");
            sb2.AppendNoneEmpty(", ", "Test1", "Test2", "Test3");

            Assert.That(sb.ToString(), Is.EqualTo("TestTest1, Test2, Test3"));
            Assert.That(sb2.ToString(), Is.EqualTo("Test1, Test2, Test3"));
        }
    }
}
