using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElmirProje.Models
{
    public class Social : BaseEntity
    {
        [Required(ErrorMessage = "Icon alani bos kecile bilmez.")]
        public string Icon { get; set; }
    }
}
