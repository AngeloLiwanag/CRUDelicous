using System.ComponentModel.DataAnnotations;
using System;
namespace Crudelicious.Models
{
    public class Dish
    {
        [Key]
        public int id {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        public string Chef {get;set;}
        [Required]
        public int Tastiness {get;set;}
        [Required]
        public int Calories {get;set;}
        [Required]
        public string Description {get;set;}
        [Required]
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
    }
}