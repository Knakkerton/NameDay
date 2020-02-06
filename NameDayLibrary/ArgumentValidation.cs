using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameDayLibrary
{
    public class ArgumentValidation
    {
        public string ValidateDate(string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "d.M.", CultureInfo.InvariantCulture);
            date = dateTime.ToString("d.M.");
            return date;
        }
    }
}
