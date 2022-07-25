using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ElmirProje.Models
{
    public class Teacher : BaseEntity
    {
        [Required(ErrorMessage = "Fullname alani bos kecile bilmez.")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "AboutMe alani bos kecile bilmez.")]
        public string AboutMe { get; set; }
        [Required(ErrorMessage = "Work alani bos kecile bilmez.")]
        public string Work { get; set; }
        [Required(ErrorMessage = "Degree alani bos kecile bilmez.")]
        public string Degree { get; set; }
        [Required(ErrorMessage = "Experience alani bos kecile bilmez.")]
        public string Experience { get; set; }
        [Required(ErrorMessage = "Hobbies alani bos kecile bilmez.")]
        public string Hobbies { get; set; }
        [Required(ErrorMessage = "Faculty alani bos kecile bilmez.")]
        public string Faculty { get; set; }
        [Required(ErrorMessage = "Mail alani bos kecile bilmez.")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "MakeACall alani bos kecile bilmez.")]
        public string MakeACall { get; set; }
        [Required(ErrorMessage = "Skype alani bos kecile bilmez.")]
        public string Skype { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }


        //Relation Property
        public List<EventTeacher> EventTeachers { get; set; }
        public List<TeacherSkill> TeacherSkills { get; set; }
    }
}
