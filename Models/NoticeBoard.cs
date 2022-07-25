using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElmirProje.Models
{
    public class NoticeBoard : BaseEntity
    {
        public NoticeBoard()
        {
            Date = DateTime.Now;
        }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Description alani bos kecile bilmez.")]
        public string Description { get; set; }
    }
}
