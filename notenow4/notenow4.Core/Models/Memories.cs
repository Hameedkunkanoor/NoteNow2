
using System;
using System.Collections.Generic;
using System.Text;


    using System;
using SQLite;

namespace notenow4.Core.Models
{
    [Table("Memories")]
    public class Memories
    {

        [PrimaryKey, AutoIncrement, Column("MemoryID")]
        public int MemoryID { get; set; }
        [Column("MemoryName")]
        public string MemoryName { get; set; }
        [Column("MemoryText")]
        public string MemoryText { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
    }
}

