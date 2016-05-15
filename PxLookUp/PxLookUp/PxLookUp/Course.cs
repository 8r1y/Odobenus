using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PxLookUp
{
    public class Course : TodoItem
    {
        public string ROWID { get; set;}
        public string datum { get; set; }
        public string datum2 { get; set; }
        public string van_uur { get; set; }
        public string tot_uur { get; set; }
        public string klas { get; set; }
        public string lokaal { get; set; }
        public string code_olod { get; set; }
        public string olod { get; set; }
        public string code_docent { get; set; }
        public string docent { get; set; }
        public string last_modified { get; set; }
    }
}
