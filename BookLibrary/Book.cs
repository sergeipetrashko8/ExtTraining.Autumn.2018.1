using System;
using System.Globalization;

namespace BookLibrary
{
    /// <summary>
    ///     The class represents a book
    /// </summary>
    public class Book : IFormattable, IComparable<Book>, IEquatable<Book>
    {
        #region IComparable methods

        /// <summary>
        ///     The methods implements comparing of 2 books by price
        /// </summary>
        /// <param name="other"><see cref="Book" /> object to compare</param>
        /// <returns>Result of comparing</returns>
        public int CompareTo(Book other)
        {
            return Price.CompareTo(other?.Price);
        }

        #endregion

        #region IEquatable methods

        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(other, this)) return true;

            if (Title.Equals(other.Title) && Author.Equals(other.Author) && Year.Equals(other.Year) &&
                Edition.Equals(other.Edition) && PublishingHours.Equals(other.PublishingHours) &&
                Pages.Equals(other.Pages) && Price.Equals(other.Price))
                return true;

            return false;
        }

        #endregion

        #region Fields

        private int _year;
        private int _edition;
        private int _pages;
        private decimal _price;

        #endregion

        #region Properties

        /// <summary>
        ///     Property Title of Book
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Property Author of Book
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        ///     Property Year of Publishing
        /// </summary>
        public int Year
        {
            get => _year;
            set
            {
                CheckPositiveNumber(value);
                _year = value;
            }
        }

        /// <summary>
        ///     Property PublishingHours of Book
        /// </summary>
        public string PublishingHours { get; set; }

        /// <summary>
        ///     Property Edition of Book
        /// </summary>
        public int Edition
        {
            get => _edition;
            set
            {
                CheckPositiveNumber(value);
                _edition = value;
            }
        }

        /// <summary>
        ///     Property count of pages of Book
        /// </summary>
        public int Pages
        {
            get => _pages;
            set
            {
                CheckPositiveNumber(value);
                _pages = value;
            }
        }

        /// <summary>
        ///     Property Price of book
        /// </summary>
        public decimal Price
        {
            get => _price;
            set
            {
                CheckPositiveNumber(value);
                _price = value;
            }
        }

        #endregion

        #region ToString methods

        /// <summary>
        ///     The method return string representation of Book
        /// </summary>
        /// <param name="format">Format string</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>String representation of Book</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "ATYP":
                    return $"Book Record: {Author}, {Title}, {Year}, {PublishingHours}";

                case "ATY":
                    return $"Book Record: {Author}, {Title}, {Year}";

                case "AT":
                    return $"Book Record: {Author}, {Title}";

                case "TYP":
                    return $"Book Record: {Title}, {Year}, {PublishingHours}";

                case "T":
                    return $"Book Record: {Title}";

                case "G":
                    return
                        $"Book Record: {Author}, {Title}, {Year}, {PublishingHours}, {Edition}, " +
                        $"{Pages}, {string.Format(formatProvider, "{0:C}", Price)}";
            }

            throw new FormatException($"There aren't \"{format}\" format string for this class!");
        }

        /// <summary>
        ///     The method return string representation of Book
        /// </summary>
        /// <param name="format">Format string</param>
        /// <returns>String representation of Book (CurrentCulture)</returns>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        ///     The method returned standard string representation of Book
        /// </summary>
        /// <returns>Standard string representation of Book</returns>
        public override string ToString()
        {
            return ToString("G");
        }

        #endregion

        #region Checkers

        private static void CheckPositiveNumber(decimal number)
        {
            if (number <= 0) throw new ArgumentException("Numeric characteristics of Book must be positive!");
        }

        private static void CheckPositiveNumber(int number)
        {
            if (number <= 0) throw new ArgumentException("Numeric characteristics of Book must be positive!");
        }

        #endregion
    }
}