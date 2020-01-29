using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculEcolage.Models
{
    public class Supervision
    {
        [PrimaryKey]
        public string name { get; set; }
        public int cost { get; set; }
    }
}
