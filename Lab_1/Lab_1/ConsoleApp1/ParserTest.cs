﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace ConsoleApp1
{
    internal class ParserTest
    {
        private Parser parser;
        private Mock<ILogger> dbLogger;
        [SetUp]
        public void SetUp()
        {
            parser = new Parser();
            dbLogger = new Mock<ILogger>();

            dbLogger.Setup(foo => foo.Log("some")).Returns(true);
            dbLogger.Setup(foo => foo.ConnectToDB()).Verifiable();
        }

        [Test]
        [TestCase ("hello", 2)]
        [TestCase ("create", 3)]
        [TestCase ("programming", 3)]
        public void word_how_many_vovels(String word, int expectedResult)
        {
            var actual = parser.howManyVowels(word);
            
            Assert.AreEqual(expectedResult, actual);
        }

        [Test]
        [TestCase("hello", 3)]
        [TestCase("create", 3)]
        [TestCase("programming", 8)]
        public void word_how_many_consonants(String word, int expectedResult)
        {
            var actual = parser.howManyСonsonants(word);

            Assert.AreEqual(expectedResult, actual);
        }

        [Test]
        [TestCase("heLLo", "HELLO")]
        [TestCase("cREaTe", "CREATE")]
        [TestCase("pROgraMMIng", "PROGRAMMING")]
        public void word_to_up(String word, String expectedResult)
        {
            var actual = parser.toUp(word);

            Assert.AreEqual(expectedResult, actual);
        }

        [Test]
        [TestCase("heLLo", "hello")]
        [TestCase("cREaTe", "create")]
        [TestCase("pROgraMMIng", "programming")]
        public void word_to_low(String word, String expectedResult)
        {
            var actual = parser.toLow(word);

            Assert.AreEqual(expectedResult, actual);
        }

        [Test]
        [TestCase("hello", "olleh")]
        [TestCase("create", "etaerc")]
        [TestCase("programming", "gnimmargorp")]
        public void word_reverse(String word, String expectedResult)
        {
            var actual = parser.reverse(word);

            Assert.AreEqual(expectedResult, actual);
        }

        [Test]
        public void dbLogger_test()
        {
            var actual = dbLogger.Object.Log("some");

            Assert.AreEqual(true, actual);
        }
    }
}
