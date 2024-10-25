using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab_5.Models
{
    public class Employee
    {
        [Key] 
        public int Code { get; set; } 

        public string LastName { get; set; } = string.Empty; 
        public string Gender { get; set; } = string.Empty; 
        public string Position { get; set; } = string.Empty; 
        public DateTime BirthDate { get; set; } 
        public decimal Salary { get; set; } 
        public int ShopNumber { get; set; } 

        public List<Bonus> Bonus { get; set; } = new List<Bonus>(); 
    }
}
