using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ElmirProje.Models
{
   
    public class Contact : BaseEntity
    {
        [Required(ErrorMessage = "Name alani bos kecile bilmez.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Message alani bos kecile bilmez.")]
        public string Message { get; set; }
        [Required(ErrorMessage = "Email alani bos kecile bilmez.")]
        public string Eamil { get; set; }
        [Required(ErrorMessage = "Subject alani bos kecile bilmez.")]
        public string Subject { get; set; }
    }
}
