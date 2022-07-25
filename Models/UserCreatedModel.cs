using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElmirProje.Models
{
    public class UserCreatedModel
    {
        [Required(ErrorMessage ="Username bos kecile bilmez.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password bos kecile bilmez.")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Tekrar password dogru deyil.")]
        public string ConfrimPassword { get; set; }
        [Required(ErrorMessage = "Email bos kecile bilmez.")]
        [EmailAddress(ErrorMessage ="Email formatinda yazi daxil edin.")]
        public string Email { get; set; }
    }
}
