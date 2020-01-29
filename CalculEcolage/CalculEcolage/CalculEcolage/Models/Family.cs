using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculEcolage.Models
{
    public class Family
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string familyName { get; set; }
        public double totalCost { get; set; }
    }
}
