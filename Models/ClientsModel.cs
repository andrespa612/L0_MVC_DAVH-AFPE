using System;
using System.ComponentModel.DataAnnotations;

namespace L0_MVC_DAVH_AFPE.Models
{
    public class ClientsModel
    {   
        
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Description { get; set; }
    }
}