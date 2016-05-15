using PxLookUp.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PxLookUp
{
    public class App : Application 
    {

        TodoItemDatabase db;

        public App()
        {
            db = new TodoItemDatabase();
            db.Update();

            MainPage = new NavigationPage(new IntroPage(db));
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
