
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using notenow4.Core.Services;
using System.IO;
using System;
using PCLStorage;

namespace notenow4.Core
{
    public partial class Application
    {

        static DBOperations database;

        public static DBOperations Database
        {
            get
            {
                if (database == null)
                {
                    var dbName = "CustomersDb.db3";
#if __ANDROID__
    string folder = Environment.GetFolderPath
      (Environment.SpecialFolder.Personal);
    var databasePath = Path.Combine(folder, dbName);
                    
                    database = new DBOperations(databasePath);
                    return database;
#else
#endif
                    // string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    // var databasePath = Path.Combine(folder, dbName);
                    // var sqliteFilename = "Notes.db3";

                    /*                    IFolder folder = FileSystem.Current.LocalStorage;
                                        string path = PortablePath.Combine(folder.Path.ToString(), sqliteFilename);
                                        System.IO.Directory.CreateDirectory(path);*/
                    // sqlitConnection = new SQLite.SQLiteConnection(path);

                    //database = new DBOperations(databasePath);

                    //database = new DBOperations(Path.Combine(Environment.getfolder)
                    //  database = new DBOperations(Path.Combine(path, "Notes.db3"));
                    //database = new DBOperations(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }
        public Application()
        {
            InitializeComponent();
        }
    }
}
