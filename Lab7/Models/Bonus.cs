using System;
using System.ComponentModel.DataAnnotations;

namespace lab_5.Models
{
    public class Bonus
    {
        [Key] 
        public int WorkerCode { get; set; } 
        public double Amount { get; set; }
        public DateTime Date { get; set; }

   
        public Employee Employee { get; set; }
    }
}
