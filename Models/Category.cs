using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RiaChristoforidouBlog.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Όνομα Κατηγορίας")]
        public string Name { get; set; }
        [Display(Name = "Φωτογραφία")]
        public string Thumbnail { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}