using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helpers
{
   public class CustomTimeZone
    {
        public  DateTime DateTimeNow()
        {
            TimeZoneInfo timeZoneInfo;
            DateTime dateTime;
            //Set the time zone information to US Mountain Standard Time 
            // India Zone "India Standard Time" Pakistan Standard Time
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            //Get date and time in US Mountain Standard Time 
            dateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            //return out the date and time
            return dateTime;
        }
    }
}
