using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Library
{
    public class HexademicalFormatter: IFormatProvider, ICustomFormatter
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
            if (arg == null || (format != null && format != "X"))
            {
                return string.Format(parent, "{0:" + format + "}", arg);                
            }
            else
            {
                long value;
                if (long.TryParse(arg.ToString(), out value))
                {
                    int bits = 64;
                    if (arg is int)
                    {
                        bits = 32;
                    }
                    return ToHexademical(value, bits);
                }
                else
                {
                    throw new FormatException("Invalid format specifier.");
                }
            }              
        }

        private static string ToHexademical(long value, int bits)
        {
            string digits = "0123456789ABCDEF";
            char[] result = new char[bits/4];
            ulong valueRepresentaion = GetRepresentation(value);
            for (int i = result.Length - 1; valueRepresentaion > 0 && i >= 0; i--)
            {
                byte digit = (byte)(valueRepresentaion % 16);
                valueRepresentaion /= 16;
                result[i] = digits[digit];
            }
            return new string(result).Trim('\0');
        }

        private static ulong GetRepresentation(long value)
        {
            ulong valueRepresentaion = (ulong)value;
            if (value < 0)
            {
                valueRepresentaion = (ulong)~Math.Abs(value) + 1;
            }
            return valueRepresentaion;
        }
    }
}
