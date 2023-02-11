﻿using System;
using System.Collections.Generic;
using System.Linq;
using Muljin.Utils;
using NUnit.Framework;

namespace Muljin.Common.Tests
{
	public class RandomStringGeneratorTests
	{
		HashSet<char> lowerCases = new HashSet<char>() { 'a', 'b', 'c','d', 'e', 'f','g','h','i','j','k','l',
			'm','n','o','p','q','r','s','t','u','v','w', 'x', 'y', 'z'};
        HashSet<char> upperCase = new HashSet<char>() { 'A', 'B', 'C','D', 'E', 'F','G','H','I','J','K','L',
            'M','N','O','P','Q','R','S','T','U','V','W', 'X', 'Y', 'Z'};

        [Test]
		public void GeneratesOnlyChars()
		{
			//arrange
            var s = RandomStringGenerator.Generate(100, true);

			//asset
			Assert.True(s.All(c => lowerCases.Contains(c) || upperCase.Contains(c)));
			Assert.True(s.Any(c => lowerCases.Contains(c)));
			Assert.True(s.Any(c => upperCase.Contains(c)));
        }

		[Test]
		public void WhenCaseInsensitiveGeneratesJustLowerCase()
		{
			var s = RandomStringGenerator.Generate(100, false);

			//assert
			Assert.True(s.All(c => lowerCases.Contains(c)));
		}


		[Test]
		public void GeneratesLengthCorrect()
		{
            var s = RandomStringGenerator.Generate(100, true);

			//assert
			Assert.AreEqual(100, s.Length);
        }
    }
}

