using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElmirProje.Models
{
    public class Skill : BaseEntity 
    {
        [Required(ErrorMessage = "Name alani bos kecile bilmez.")]
        public string Name { get; set; }
        

        //Relation Property

        public List<TeacherSkill> TeacherSkills { get; set; }
    }
}
