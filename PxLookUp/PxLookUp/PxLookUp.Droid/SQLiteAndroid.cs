using System.IO;
using PxLookUp;
using Xamarin.Forms;

[assembly: Dependency (typeof (SQLiteAndroid))]

    public class SQLiteAndroid : ISQLite
    {
        public SQLiteAndroid() { }

        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "TodoSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);

            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
