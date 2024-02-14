using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koolitused.Models
{
    public class Opilane
    {
        public int Id { get; set; }
        public string Eesnimi { get; set; }
        public string Perenimi { get; set; }
        public int Sunniaasta { get; set; }
    }
}