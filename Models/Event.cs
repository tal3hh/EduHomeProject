using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ElmirProje.Models
{
    public class Event : BaseEntity
    {
        public Event()
        {
            Date = DateTime.Now;
        }
        [Required(ErrorMessage = "Title alani bos kecile bilmez.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Location alani bos kecile bilmez.")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Description alani bos kecile bilmez.")]
        public string Description { get; set; }
        
        public string Image { get; set; }
        [Required(ErrorMessage = "StartDate alani bos kecile bilmez.")]
        public string StartDate { get; set; }
        [Required(ErrorMessage = "EndDate alani bos kecile bilmez.")]
        public string EndDate { get; set; }
        public DateTime Date { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }


        //Realtion Property

        public List<EventTeacher> EventTeachers { get; set; }
    }
}
