using PxLookUp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PxLookUp
{
    public class TodoItemDatabase
    {
        SQLiteConnection database;

        public TodoItemDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Course>();
            database.CreateTable<Menu>();
        }

        public IEnumerable<Course> GetCourses()
        {
            return (from i in database.Table<Course>() select i).ToList();
        }
        public List<Course> GetCourseByRoom(string room)
        {
            return database.Query<Course>("SELECT * FROM Course WHERE lokaal = '" + room + "'"); 
        }
        public List<Course> GetCourseByGroup(string group)
        {
            return database.Query<Course>("SELECT * FROM Course WHERE klas = '" + group + "'");
        }
        public List<Course> GetCourseByTeacher(string teacher)
        {
            return database.Query<Course>("SELECT * FROM Course WHERE docent = '" + teacher + "'");
        }
        public List<Menu> GetMenusByLocation(string location)
        {
            return database.Query<Menu>("SELECT * FROM Menu WHERE Locatie = '" + location + "'");
        }

        public void InsertCourses(List<Course> courses)
        {
            foreach(var v in courses)
            {
                database.Insert(v);
            }     
        }
        public void InsertMenus(List<Menu> menus)
        {
            foreach (var v in menus)
            {
                database.Insert(v);
            }
        }
        public void DeleteCourses()
        {
            database.DeleteAll<Course>();
        }
        public void Update()
        {
            //var count = (from v in database.Table<Course>().AsEnumerable() select v).Count();

            DeleteCourses();
            InsertCourses(new RestService().GetCoursesAsync().Result);
            InsertMenus(new RestService().GetMenusAsync().Result);
        }

        public List<Course> GetCourseByColumn(string column)
        {
            var d = database.Query<Course>("SELECT DISTINCT " + column + " FROM Course");
            return d;
        }

        public List<Menu> GetMenuByColumn(string column)
        {
            var d = database.Query<Menu>("SELECT DISTINCT " + column + " FROM Menu");
            return d;
        }
    }
}
