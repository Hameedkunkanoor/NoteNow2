using System;
using System.Collections.Generic;
using System.Text;


    using System;
using SQLite;

namespace notenow4.Core.Models
{
    [Table("Notes")]
    public class Notes
    {
       
        [PrimaryKey, AutoIncrement, Column("NotesID")]
        public int NotesID { get; set; }
        [ Column("NotesName")]
        public string NotesName { get; set; }
        [Column("NotesText")]
        public string NotesText { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
    }
}
