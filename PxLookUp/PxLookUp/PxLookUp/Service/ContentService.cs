using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PxLookUp
{
    public class ContentService
    {
        public List<Course> FilterCoursesByDay(List<Course> list, int dayindex)
        {
            DateTime ClockInfoFromSystem = DateTime.Now;

            var today = (int)ClockInfoFromSystem.DayOfWeek;
            var date = Convert.ToInt32(ClockInfoFromSystem.Date.ToString("dd"));

            var searchDate = ClockInfoFromSystem.AddDays(dayindex - today);
            var v = searchDate.Date.ToString("dd/MM/yy");

            List<Course> ToDayCourse = list.Where(c => c.datum.Equals(searchDate.Date.ToString("dd/MM/yy"))).ToList<Course>();

            return ToDayCourse;    
        }
    }
}
