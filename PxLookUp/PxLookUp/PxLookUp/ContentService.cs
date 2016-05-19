using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PxLookUp
{
    public class ContentService
    {
        public List<Course> FilterByDay(List<Course> list, string s)
        {
            HashSet<int> days = new HashSet<int>();
            HashSet<int> months = new HashSet<int>();

            foreach(var v in list)
            {
                days.Add(Convert.ToInt32(v.datum.Split('/')[0]));
                months.Add(Convert.ToInt32(v.datum.Split('/')[1]));
            }

            bool isEndOfMonth = false;
            bool isEndOfYear = false;

            if (months.Count > 1)
            {
                isEndOfMonth = true;

                if (Math.Abs((months.ElementAt(0) - months.ElementAt(1))) > 1){
                    isEndOfYear = true;
                }
            }

            List<int> orderedDays = null; 

            if (!isEndOfMonth)
            {
                orderedDays = days.OrderBy(i => i).ToList(); ;
            }

            List<Course> sortedDays = new List<Course>();
            int index = -1;
            switch (s)
            {
                case "Monday":
                    index = 0;
                    break;
                case "Tuesday":
                    index = 1;
                    break;
                case "Wednesday":
                    index = 2;
                    break;
                case "Thursday":
                    index = 3;
                    break;
                case "Friday":
                    index = 4;
                    break;
            }

            if(index != -1)
            {
                foreach(var v in list)
                {
                    if (Convert.ToInt32(v.datum.Split('/')[0]) == (orderedDays.ElementAt(index)))
                    {
                        sortedDays.Add(v);
                    }
                }
            }

            return sortedDays;

            
        }


    }
}
