using System;
using System.Globalization;
using BookLibrary;

namespace BookExtension
{
    /// <summary>
    ///     The class extends capabilities of Book's ToString method
    /// </summary>
    public class BookFormatExtension : IFormatProvider, ICustomFormatter
    {
        private readonly IFormatProvider _parent;

        /// <summary>
        ///     Default constructor
        /// </summary>
        public BookFormatExtension() : this(CultureInfo.CurrentCulture)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="parent"><see cref="IFormatProvider" /> object</param>
        public BookFormatExtension(IFormatProvider parent)
        {
            if (ReferenceEquals(parent, null)) _parent = CultureInfo.CurrentCulture;
            _parent = parent;
        }

        /// <summary>
        ///     Method extends formatting of format string for <see cref="Book" /> object
        /// </summary>
        /// <param name="format">Format <see cref="string" /></param>
        /// <param name="arg">Object to format</param>
        /// <param name="formatProvider"><see cref="IFormatProvider" /> object</param>
        /// <returns>Formatted string</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (format.ToUpperInvariant() != "PRICE" || ReferenceEquals(arg, null))
                return string.Format(_parent, "{0:" + format + "}", arg);

            return "Book Record: " + ((Book) arg).Price.ToString("C", _parent);
        }

        /// <summary>
        ///     The method returns object of <see cref="IFormatProvider" />
        /// </summary>
        /// <param name="formatType">Type of format type</param>
        /// <returns>Returns object of <see cref="IFormatProvider" /></returns>
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }
    }
}