using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElmirProje.Models
{
    public class CourseFeatures : BaseEntity
    {
        [Required(ErrorMessage = "Start alani bos kecile bilmez.")]
        public string Start { get; set; }
        [Required(ErrorMessage = "Duration alani bos kecile bilmez.")]
        public string Duration { get; set; }
        [Required(ErrorMessage = "ClassDuration alani bos kecile bilmez.")]
        public string ClassDuration { get; set; }
        [Required(ErrorMessage = "Language alani bos kecile bilmez.")]
        public string Language { get; set; }
        [Required(ErrorMessage = "SkillLevel alani bos kecile bilmez.")]
        public string SkillLevel { get; set; }
        [Required(ErrorMessage = "Students alani bos kecile bilmez.")]
        public string Students { get; set; }
        [Required(ErrorMessage = "Assesments alani bos kecile bilmez.")]
        public string Assesments { get; set; }
        [Required(ErrorMessage = "CourseFee alani bos kecile bilmez.")]
        public string CourseFee { get; set; }

        public int CourseId { get; set; }
        //Relation Property

        public Course Course { get; set; }
    }
}
