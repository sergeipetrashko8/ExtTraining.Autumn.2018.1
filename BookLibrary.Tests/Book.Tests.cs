using System;
using System.Globalization;
using NUnit.Framework;

namespace BookLibrary.Tests
{
    [TestFixture]
    public class BookTests
    {
        private Book _book;

        [OneTimeSetUp]
        public void SetUp()
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("cn-CN");

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

        [TestCase("ATYP", ExpectedResult = "Book Record: Jon Skeet, C# in Depth, 2019, Manning")]
        [TestCase("ATY", ExpectedResult = "Book Record: Jon Skeet, C# in Depth, 2019")]
        [TestCase("AT", ExpectedResult = "Book Record: Jon Skeet, C# in Depth")]
        [TestCase("TYP", ExpectedResult = "Book Record: C# in Depth, 2019, Manning")]
        [TestCase("T", ExpectedResult = "Book Record: C# in Depth")]
        [TestCase("G", ExpectedResult = "Book Record: Jon Skeet, C# in Depth, 2019, Manning, 4, 900, ¤40.00")]
        public string ToString_FormatStringInvariantCulture_FormatedStringExpected(string format)
        {
            return _book.ToString(format, CultureInfo.InvariantCulture);
        }

        [Test]
        public void ToString_DefaultToString_DefaultToStringExpected()
        {
            var expected = _book.ToString();
            var actual = _book.ToString("G", null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_FormatStringGTurkeyCulture_FormatedStringExpected()
        {
            var expected = string.Format(CultureInfo.GetCultureInfo("tr-TR"),
                "Book Record: Jon Skeet, C# in Depth, 2019, Manning, 4, 900, {0:C}", _book.Price);
            var actual = _book.ToString("G", CultureInfo.GetCultureInfo("tr-TR"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_InvalidFormatSting_FormatExceptionExpected()
        {
            Assert.Throws<FormatException>(() => _book.ToString("R", null));
        }
    }
}