using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElmirProje.Models
{
    public class Service : BaseEntity
    {
        [Required(ErrorMessage = "Title alani bos kecile bilmez.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description alani bos kecile bilmez.")]
        public string Description { get; set; }
    }
}
