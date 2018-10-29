using System;
using System.Globalization;

namespace BookLibrary
{
    /// <summary>
    /// The class represents a book
    /// </summary>
    public class Book : IFormattable
    {
        private int _year;
        private int _edition;
        private int _pages;
        private double _price;

        /// <summary>
        /// Property Title of Book
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Property Author of Book
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Property Year of Publishing
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
        /// Property PublishingHours of Book
        /// </summary>
        public string PublishingHours { get; set; }

        /// <summary>
        /// Property Edition of Book
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
        /// Property count of pages of Book
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
        /// Property Price of book
        /// </summary>
        public double Price
        {
            get => _price;
            set
            {
                CheckPositiveNumber(value);
                _price = value;
            }
        }

        /// <summary>
        /// The method return string representation of Book
        /// </summary>
        /// <param name="format">Format string</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>String representation of Book</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format)
            {
                case "ATYP":
                    return "Book Record: " + Author + ", " + Title + ", " + Year.ToString(formatProvider) + ", " + PublishingHours;

                case "ATY":
                    return "Book Record: " + Author + ", " + Title + ", " + Year.ToString(formatProvider);

                case "AT":
                    return "Book Record: " + Author + ", " + Title;

                case "TYP":
                    return "Book Record: " + Title + ", " + Year.ToString(formatProvider) + ", " + PublishingHours;

                case "T":
                    return "Book Record: " + Title;

                case "G":
                    return "Book Record: " + Author + ", " + Title + ", " + Year.ToString(formatProvider) + ", " + PublishingHours + ", " + Edition.ToString(formatProvider)
                           + ", " + Pages.ToString(formatProvider) + ", " + string.Format(formatProvider, "{0:C}", Price);
            }

            throw new FormatException($"There aren't \"{format}\" format string for this class!");
        }

        /// <summary>
        /// The method returned standard string representation of Book
        /// </summary>
        /// <returns>Standard string representation of Book</returns>
        public override string ToString()
        {
            return ToString("G", null);
        }

        private static void CheckPositiveNumber(double number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("Numeric characteristics of Book must be positive!");
            }
        }
    }
}
