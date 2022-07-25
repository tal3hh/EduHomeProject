using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElmirProje.Models
{
    public class Testimonial : BaseEntity
    {
        [Required(ErrorMessage = "Fullname alani bos kecile bilmez.")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Description alani bos kecile bilmez.")]
        public string Description { get; set; }
        
        public string Image { get; set; }
        [Required(ErrorMessage = "Work alani bos kecile bilmez.")]
        public string Work { get; set; }
    }
}
