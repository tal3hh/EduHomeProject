using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElmirProje.Models
{
    public class Subscribee : BaseEntity
    {
        [Required(ErrorMessage ="Email alani bos kecile bilmez.")]
        [EmailAddress(ErrorMessage ="Email formatinda yazi daxil edin.")]
        public string Email { get; set; }
        public bool IsActived { get; set; } = false;
    }
}
