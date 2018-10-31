using System;

namespace StringExtension
{
    /// <summary>
    ///     The class implements parsing string to int number of some base
    /// </summary>
    public static class Parser
    {
        private const string Numbers = "0123456789ABCDEF";

        /// <summary>
        ///     The method parse string to int number of some base
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="base">Base of number</param>
        /// <returns>Parsed integer number</returns>
        public static int ToDecimal(this string source, int @base)
        {
            CheckBase(@base);
            CheckSourceString(source, @base);

            source = source.ToUpperInvariant();

            var resultNumber = 0;
            var powOfInt = 1;

            try
            {
                for (var i = source.Length - 1; i >= 0; i--)
                {
                    checked
                    {
                        resultNumber = resultNumber + Numbers.IndexOf(source[i]) * powOfInt;
                        if (i > 0) powOfInt *= @base;
                    }
                }

                return resultNumber;
            }

            catch (OverflowException ex)
            {
                throw new ArgumentException($"{nameof(source)} string has too big value!", ex);
            }
        }

        #region Checkers

        private static void CheckBase(int @base)
        {
            if (!(@base >= 2 && @base <= 16)) throw new ArgumentOutOfRangeException(nameof(@base));
        }

        private static void CheckSourceString(string source, int @base)
        {
            if (source == null) throw new ArgumentNullException("Source string has null reference!");

            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentException("Source string has zero length or white space!");

            source = source.ToUpperInvariant();
            var numbers = Numbers.Substring(0, @base);

            foreach (var element in source)
            {
                if (!numbers.Contains(element.ToString()))
                    throw new ArgumentException("Source string contains invalid symbols for this base!");
            }
        }

        #endregion
    }
}