using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Travelapp.Model
{
    public class post
    {
        [PrimaryKey , AutoIncrement]
        public int Id { get; set; }

        [MaxLength(300)]
        public string Experience { get; set; }
    }
}
