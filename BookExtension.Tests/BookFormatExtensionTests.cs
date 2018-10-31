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

        [TestCaseSource(typeof(Data), nameof(Data.DataStrings))]
        public void ToString_FormatString_FormattedStringExpected(string format, string culture, string expected)
        {
            var actual = string.Format(new BookFormatExtension(CultureInfo.GetCultureInfo(culture)),
                "{0:" + format + "}", _book);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_InvalidFormatSting_FormatExceptionExpected()
        {
            Assert.Throws<FormatException>(() => string.Format(new BookFormatExtension(), "{0:U}", _book));
        }

        [Test]
        public void ToString_BookObjectHasNullReference_ArgumentNullExceptionExpected()
        {
            Assert.Throws<ArgumentNullException>(() => string.Format(new BookFormatExtension(), "{0:PRICE}", null));
        }
    }

    public static class Data
    {
        public static string[][] DataStrings => new[]
        {
            new[] {"prIcE", "en-US", "Book Record: $40.00"},
            new[] {"PrIcE", "tr-TR", "Book Record: ₺40,00"},
            new[] {"PrIcE", "in", "Book Record: ¤40.00"},
            new[] {"PrIcE", "in", "Book Record: ¤40.00"}
        };
    }
}