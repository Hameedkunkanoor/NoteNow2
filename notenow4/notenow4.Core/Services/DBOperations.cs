using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using notenow4.Core.Models;
using System.Threading.Tasks;

namespace notenow4.Core.Services
{
   public class DBOperations
    {
        
        readonly SQLiteAsyncConnection _database;

        public DBOperations(string dbPath)
        {
            try
            {
                _database = new SQLiteAsyncConnection(dbPath);
               
                _database.CreateTableAsync<Notes>().Wait();
            }
            catch(Exception ex)
            {

            }
        }

        public Task<List<Notes>> GetNotes()
        {
            return _database.Table<Notes>().ToListAsync();
        }

        public Task<Notes> GetNotsAsync(int id)
        {
            return _database.Table<Notes>()
                            .Where(i => i.NotesID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNotes(Notes note)
        {
            if (note.NotesID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNotes(Notes note)
        {
            return _database.DeleteAsync(note);
        }
    }
}
