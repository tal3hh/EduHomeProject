using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ElmirProje.Models
{
    
    public class BioTable : BaseEntity
    {
        [Required(ErrorMessage = "PhoneNumber alani bos kecile bilmez.")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Adress alani bos kecile bilmez.")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Email alani bos kecile bilmez.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "SiteLink alani bos kecile bilmez.")]
        public string SiteLink { get; set; }
    }
}
