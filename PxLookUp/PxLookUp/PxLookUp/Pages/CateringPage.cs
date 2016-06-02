using PxLookUp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PxLookUp.Pages
{
    public class CateringPage : TabbedPage
    {
        public CateringPage(TodoItemDatabase db, string value)
        {
            this.Title = value;

            List<Menu> list = db.GetMenusByLocation(value);
        }
    }
}
