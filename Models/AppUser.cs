using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ElmirProje.Models
{
    public class AppUser : IdentityUser<int>
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
