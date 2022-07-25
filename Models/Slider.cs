using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ElmirProje.Models
{
    public class Slider : BaseEntity
    {
        [Required(ErrorMessage = "Title alani bos kecile bilmez.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description alani bos kecile bilmez.")]
        public string Description { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
