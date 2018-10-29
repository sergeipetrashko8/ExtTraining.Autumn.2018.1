using System;
using NUnit.Framework;

namespace StringExtension.Tests
{
    [TestFixture]
    public class ParserTests
    {
        [Test]
        public void StringToDecimal_NullString_ThrowsArgumentNullException() 
            => Assert.Throws<ArgumentNullException>(() => ((string)null).ToDecimal(2));

        [TestCase(1)]
        [TestCase(-5)]
        [TestCase(17)]
        [TestCase(20)]
        public void StringToDecimal_WrongBase_ThrowsArgumentOutOfRangeException(int @base) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => "a".ToDecimal(@base));

        [TestCase("1AeF101", 2)]
        [TestCase("SA123", 2)]
        [TestCase("43256", 3)]
        [TestCase("10102", 2)]
        [TestCase("-sdfj", 3)]
        public void StringToDecimal_SymbolsNotInBase_ThrowsArgumentException(string source, int @base) =>
            Assert.Throws<ArgumentException>(() => source.ToDecimal(@base));

        [TestCase("111111111111111111111111111111111", 2)]
        [TestCase("535A79889", 13)]
        [TestCase("1550104015504", 6)]
        public void StringToDecimal_TooBigValue_ThrowsArgumentException(string source, int @base) =>
            Assert.Throws<ArgumentException>(() => source.ToDecimal(@base));

        [TestCase("0110111101100001100001010111111", 2, ExpectedResult = 934331071)]
        [TestCase("01101111011001100001010111111", 2, ExpectedResult = 233620159)]
        [TestCase("11101101111011001100001010", 2, ExpectedResult = 62370570)]
        [TestCase("1AeF101", 16, ExpectedResult = 28242177)]
        [TestCase("1ACB67", 16, ExpectedResult = 1756007)]
        [TestCase("764241", 8, ExpectedResult = 256161)]
        [TestCase("10011", 2, ExpectedResult = 19)]
        [TestCase("10", 5, ExpectedResult = 5)]
        [TestCase("437abc", 16, ExpectedResult = 4422332)]
        [TestCase("332", 4, ExpectedResult = 62)]
        [TestCase("bc3215", 13, ExpectedResult = 4433902)]
        [TestCase("213423412", 10, ExpectedResult = 213423412)]
        public int StringToDecimal_ValidInput_ValidResult(string source, int @base) 
            => source.ToDecimal(@base);
    }
}
