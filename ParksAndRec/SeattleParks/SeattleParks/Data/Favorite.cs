using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeattleParks.Data
{
    public class Favorite
    {
        [PrimaryKey]
        public int Id { get; set; }
    }
}
