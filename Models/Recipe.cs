using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RiaChristoforidouBlog.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Τίτλος")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Περιγραφή")]
        public string Description { get; set; }
        [Display(Name = "Κατηγορία")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}