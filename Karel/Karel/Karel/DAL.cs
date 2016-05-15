using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Karel
{
    public class DAL
    {
        string DatabasePath
        {
            get
            {
                var sqliteFilename = "TodoSQLite.db3";
                #if __IOS__
                    string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                    string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
                    var path = Path.Combine(libraryPath, sqliteFilename);
                #else
                #if __ANDROID__
                    string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
                    var path = Path.Combine(documentsPath, sqliteFilename);
                #else
                // WinPhone
                    var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);;
                #endif
                #endif
                return path;
            }
        }


        public DAL() { }
    }
}
