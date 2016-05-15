using System;
using System.Collections.Generic;
using System.Text;

namespace Karel
{
    public class RootObject
    {
        public Course[] Courses { get; set; }

        public class Course
        {
            public string ROWID { get; set; }
            public string datum { get; set; }

        }
    }
}
