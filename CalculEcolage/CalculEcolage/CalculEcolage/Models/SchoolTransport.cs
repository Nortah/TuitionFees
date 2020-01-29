using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculEcolage.Models
{
    public class SchoolTransport
    {
        [PrimaryKey]
        public string zone { get; set; }
        public int cost { get; set; }
    }
}
