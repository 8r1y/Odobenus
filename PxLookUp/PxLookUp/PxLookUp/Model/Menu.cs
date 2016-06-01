using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PxLookUp.Model
{
    public class Menu : TodoItem
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Datum { get; set; }
        public string Voorgerecht { get; set; }
        public string HoofdGerecht { get; set; }
        public string NaGerecht { get; set; }
        public string WeekSoep { get; set; }
        public string MaaltijdSoepEnBrood { get; set; }
        public string Veggie { get; set; }
        public string Aanrader { get; set; }
        public string PastaVanDeDag { get; set; }
        public string Suggestie { get; set; }
        public string Locatie { get; set; }
        public string HealthFood { get; set; }
        public string SnackVanDeDag { get; set; }
    }
}
