using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Koolitused.Models
{
    public class RegKursile
    {
        public int Id { get; set; }
        [DisplayName("Eesnimi")]
        public string FirstName { get; set; }
        [DisplayName("Perenimi")]
        public string LastName { get; set; }
        [DisplayName("Kurssi nimetus")]
        public int CourseId { get; set; }

        public virtual Koolituss Course { get; set; }

        public string UserEmail { get; set; }
    }
}