using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProiectMedii.Models
{
    public class Priority
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nume { get; set; }
        [OneToMany]
        public List<Job> Jobs { get; set; }
    }
}
