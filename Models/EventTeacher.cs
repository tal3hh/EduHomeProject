using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElmirProje.Models
{
    public class EventTeacher : BaseEntity
    {
        public int EventId { get; set; }
        public int TeacherId { get; set; }


        //Realtion Property 

        public Teacher Teacher { get; set; }
        public Event Event { get; set; }
    }
}
