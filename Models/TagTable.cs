using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElmirProje.Models
{
    public class TagTable : BaseEntity
    {
        [Required(ErrorMessage = "Name alani bos kecile bilmez.")]
        public string Name { get; set; }
    }
}
