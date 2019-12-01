
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

        public static readonly object Context;

        static DBOperations database;
       
        public static DBOperations Database
        {
            get
            {
                try
                {
                    if (database == null)
                    {
                        var dbName = "Notes.db3";

                      
                        var sqliteFilename = "Notes.db3";

                        IFolder folder = FileSystem.Current.LocalStorage;
                        
                        string path = PortablePath.Combine(folder.Path.ToString(), sqliteFilename);
                       
                       
                      

                        database = new DBOperations(Path.Combine(path));
                       }
                    return database;
                }
                catch(Exception ex)
                {
                    var dbName = "Notes.db3";

                   
                    var sqliteFilename = "Notes.db3";

                    IFolder folder = FileSystem.Current.LocalStorage;

                    string path = PortablePath.Combine(folder.Path.ToString(), sqliteFilename);
                    System.IO.Directory.CreateDirectory(path);

                    database = new DBOperations(Path.Combine(path));
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
