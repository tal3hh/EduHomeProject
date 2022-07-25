using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ElmirProje.Models
{
    
    public class Blog : BaseEntity
    {
        public Blog()
        {
            Date = DateTime.Now;
        }
        [Required(ErrorMessage ="Title alani bos kecile bilmez.")]
        public string Title { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "TeacherName alani bos kecile bilmez")]
        public string TeacherName { get; set; }
        [Required(ErrorMessage = "Description alani bos kecile bilmez")]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int? CommentCount { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
