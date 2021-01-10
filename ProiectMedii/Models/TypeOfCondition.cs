using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProiectMedii.Models
{
    public class TypeOfCondition
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Tip { get; set; }

        [OneToMany]
        public List<Job> Jobs { get; set; }
    }
}
