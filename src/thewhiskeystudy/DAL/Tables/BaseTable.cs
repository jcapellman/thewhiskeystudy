using System;
using System.ComponentModel.DataAnnotations;

namespace thewhiskeystudy.DAL.Tables
{
    public class BaseTable
    {
        [Key]
        public int ID { get; set; }

        public bool Active { get; set; }

        public DateTime Modified { get; set; }

        public DateTime Created { get; set; }
    }
}