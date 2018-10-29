using System;
using System.Globalization;
using NUnit.Framework;

namespace BookLibrary.Tests
{
    [TestFixture]
    public class BookTests
    {
        private CultureInfo _ci;

        private Book _book;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");

            _ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            _ci.NumberFormat.CurrencyDecimalSeparator = ".";
            _ci.NumberFormat.CurrencySymbol = "$";

            _book  = new Book
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
        public string ToString_FormatString_FormatedStringExpected(string format)
        {
            return _book.ToString(format, null);
        }

        [Test]
        public void ToString_DefaultToString_DefaultToStringExpected()
        {
            string expected = _book.ToString();
            string actual = _book.ToString("G", null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_InvalidFormatSting_FormatExceptionExpected()
        {
            Assert.Throws<FormatException>(() => _book.ToString("R", null));
        }
    }
}
