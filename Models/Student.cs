using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace L0_MVC_DAVH_AFPE.Models
{
    public class Student
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string name { get; set; }
        
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Birth { get; set; }
        public int age { get; set; }
    }
}
