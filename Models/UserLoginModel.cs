using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElmirProje.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="Username bos kecile bilmez.")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Password bos kecile bilmez.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
