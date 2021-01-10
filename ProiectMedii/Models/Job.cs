using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace ProiectMedii.Models
{
    public class Job
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Descriere { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(typeof(TypeOfCondition))]
        public int TypeId { get; set; }

        [ForeignKey(typeof(Priority))]
        public int PriorityId { get; set; }
    }
}
