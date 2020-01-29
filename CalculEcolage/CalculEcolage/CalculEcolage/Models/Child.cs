using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculEcolage.Models
{
    public class Child
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string childName { get; set; }
        public string yearName { get; set; }
        public string assistanceDiscountName { get; set; }
        public string siblingDiscountName { get; set; }
        public string termDiscountName { get; set; }
        public string zoneName { get; set; }
        public string supervisionName { get; set; }
        public string supportName { get; set; }
        public int enrolementFee { get; set; }
        public int tuitionFees { get; set; }
        public double recalculatedTuitionFees { get; set; }
        public int fixedCharges { get; set; }
        public int externalExaminationFees { get; set; }
        public int schoolMeals { get; set; }
        public int wednesdayMeals { get; set; }
        public double assistanceDiscount { get; set; }
        public double siblingDiscount { get; set; }
        public double termDiscount { get; set; }
        public int schoolTransport { get; set; }
        public int supervision { get; set; }
        public int support { get; set; }

        public double cost { get; set; }
        public int familyId { get; set; }
        public Child BindingContext { get; internal set; }
    }
}
