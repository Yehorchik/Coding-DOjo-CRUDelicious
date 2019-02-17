using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDelicious.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get; set;}
        [Required]
        [MinLength(3)]
        public string FirstName {get;set;}
        [Required]
        [MinLength(3)]
        public string LastName {get;set;}
        [Required]
        public DateTime Age {get; set;}

        public List<Dishes> Dishes {get; set;}

        [NotMapped]
        public int DoB {get; set;}
    }
}