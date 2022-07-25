using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElmirProje.Models
{
    public class TeacherSkill : BaseEntity 
    {
        public int TeacherId { get; set; }
        public int SkillId { get; set; }
        [Required(ErrorMessage = "Degree alani bos kecile bilmez.")]
        public int Degree { get; set; }


        //Relation Property

        public Teacher Teacher { get; set; }
        public Skill Skill { get; set; }
    }
}
