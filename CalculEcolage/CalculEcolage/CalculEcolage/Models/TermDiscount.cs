using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculEcolage.Models
{
    public class TermDiscount
    {
        [PrimaryKey]
        public string name { get; set; }
        public int discountPercentage { get; set; }
    }
}
