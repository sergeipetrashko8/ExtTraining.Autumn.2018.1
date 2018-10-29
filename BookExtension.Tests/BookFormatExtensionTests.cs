using System;
using System.Globalization;
using BookLibrary;
using NUnit.Framework;

namespace BookExtension.Tests
{
    public class BookFormatExtensionTests
    {
        private Book _book;

        [OneTimeSetUp]
        public void SetUp()
        {
            _book = new Book
            {
                Author = "Jon Skeet",
                Year = 2019,
                Price = 40,
                Title = "C# in Depth",
                PublishingHours = "Manning",
                Edition = 4,
                Pages = 900
            };
        }

        [TestCase("A", ExpectedResult = "Book Record: Jon Skeet")]
        public string ToString_FormatString_FormatedStringExpected(string format)
        {
            return string.Format(new BookFormatExtension(), "{0:A}", _book);
        }

        [Test]
        public void ToString_InvalidFormatSting_FormatExceptionExpected()
        {
            Assert.Throws<FormatException>(() => string.Format(new BookFormatExtension(), "{0:U}", _book));
        }
    }
}
