using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Library
{
    class HexademicalFormatter: IFormatProvider, ICustomFormatter
    {
        private IFormatProvider parent;
        public HexademicalFormatter()
            : this(CultureInfo.CurrentCulture)  { }
        public HexademicalFormatter(IFormatProvider parent)
        {
            this.parent = parent;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!this.Equals(formatProvider))
                return null;
            if (arg == null || format != "X")
                return string.Format(parent, "{0:" + format + "}", arg);

            long value;
            if (Int64.TryParse(arg.ToString(), out value))
            {
                return ToHexademical(value);  
            }
            else
            {
                throw new FormatException("Invalid format specifier.");
            }                 
        }

        private static string ToHexademical(int value)
        {
            StringBuilder result = new StringBuilder();
            if (value < 0)
            {
                value = ~Math.Abs(value) + 1;
            }
            while (value > 15)
            {
                byte digit = (byte)(value % 16);
                value /= 16;
                result.Append(digit.ToString("X"));
            }
            result.Append(value.ToString("X"));
            return result.ToString();
        }
    }
}
