using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagogoEventFinder;

namespace ViagogoEventFinderTest
{
    [TestClass]
    public class InputParserTest
    {
        [TestMethod]
        public void TestInputParserStandardValidInput()
        {
            LocationVector parsed = InputParser.Parse("-2, 4");
            LocationVector expected = new LocationVector(-2, 4);

            Assert.AreEqual(expected.x, parsed.x);
            Assert.AreEqual(expected.y, parsed.y);
        }

        [TestMethod]
        public void TestInputParserMessyValidInput()
        {
            LocationVector parsed = InputParser.Parse("  -6,10 ");
            LocationVector expected = new LocationVector(-6, 10);

            Assert.AreEqual(expected.x, parsed.x);
            Assert.AreEqual(expected.y, parsed.y);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestInvalidInputTooManyValues()
        {
            LocationVector parsed = InputParser.Parse("-2, 4, 6");
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestInvalidInputNotIntegers()
        {
            LocationVector parsed = InputParser.Parse("-2.2, 4");
            LocationVector expected = new LocationVector(-6, 4);

            Assert.AreEqual(expected.x, parsed.x);
            Assert.AreEqual(expected.y, parsed.y);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestInvalidInputCharacters()
        {
            LocationVector parsed = InputParser.Parse("-2, 4w");
        }
    }
}