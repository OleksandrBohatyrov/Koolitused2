using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Koolitused.Models
{
    public class Koolituss
    {
        public int Id { get; set; }
        public string Koolitusnimetus { get; set; }
        public int Koolitushind { get; set; }
        public int Koolitusmaht { get; set; }
        public string OpetajaEesnimi { get; set; }
        public string OpetajaPerenimi { get; set; }

        public virtual ICollection<RegKursile> Registrations { get; set; }
    }
}