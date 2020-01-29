using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CalculEcolage.Algorithms
{
    public class GetNumberSep
    {

        public string ToNumberFormat(double number)
        {
            decimal amount = (decimal) number;
            NumberFormatInfo nfi = (NumberFormatInfo)
            CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "'";

            return amount.ToString("n", nfi);
        }
    }
}
