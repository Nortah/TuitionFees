using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculEcolage.Models
{
    public class EnrolementFees
    {
        [PrimaryKey]
        public int id { get; set; }
        public int cost { get; set; }

        
    }
}
