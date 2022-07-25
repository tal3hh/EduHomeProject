using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElmirProje.Models
{
    public class CourseDetails : BaseEntity
    {
        [Required(ErrorMessage ="About alani bos kecile bilmez.")]
        public string About { get; set; }
        [Required(ErrorMessage = "Certificate alani bos kecile bilmez.")]
        public string Certificate { get; set; }
        [Required(ErrorMessage = "HowToApply alani bos kecile bilmez.")]
        public string HowToApply { get; set; }
        public int CourseCount { get; set; }


        public int CourseId { get; set; }

        //Relation Property

        public Course Course { get; set; }
    }
}
