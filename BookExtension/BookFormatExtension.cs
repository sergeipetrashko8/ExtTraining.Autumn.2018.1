using System;
using System.Globalization;
using BookLibrary;

namespace BookExtension
{
    /// <summary>
    /// The class extends capabilities of Book's ToString method 
    /// </summary>
    public class BookFormatExtension : IFormatProvider, ICustomFormatter
    {
        private readonly IFormatProvider _parent;

        /// <summary>
        /// Default constructor
        /// </summary>
        public BookFormatExtension()
        {
            _parent = CultureInfo.CurrentCulture;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent"><see cref="IFormatProvider"/> object</param>
        public BookFormatExtension(IFormatProvider parent)
        {
            _parent = parent;
        }

        /// <summary>
        /// The method returns object of <see cref="IFormatProvider"/>
        /// </summary>
        /// <param name="formatType">Type of format type</param>
        /// <returns>Returns object of <see cref="IFormatProvider"/></returns>
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {       
            if (arg.GetType() != typeof(Book) || format != "A" && format != "a")
            {
                return string.Format(_parent, "{0:" + format + "}", arg);
            }
            
            return "Book Record: " + ((Book) arg).Author;
        }
    }
}
