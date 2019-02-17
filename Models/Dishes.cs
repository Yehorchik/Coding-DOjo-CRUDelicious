using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dishes
    {
        [Key]
        public int DishId {get;  set;}
        [Required]
        [MinLength(4)]
        public string Name {get; set;}
        public int Tastiness {get; set;}
        public int Calories {get; set;}
        public string Description {get; set;}

        public int ChefId {get;set;}

        public Chef Chef {get;set;}
    }
}