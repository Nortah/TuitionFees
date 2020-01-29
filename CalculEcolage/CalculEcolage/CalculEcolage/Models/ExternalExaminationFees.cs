using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculEcolage.Models
{
    public class ExternalExaminationFees
    {
        [PrimaryKey]
        public string yearName { get; set; }
        public int cost { get; set; }

    }
}
