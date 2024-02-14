using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Koolitused.Models
{
    public class GuestContext : DbContext
    {
        public DbSet<Opilane> Opilased { get; set; }
        public DbSet<Opetaja> Opetajad { get; set; }
        public DbSet<Koolituss> Koolitused { get; set; }
        public DbSet<RegKursile> RegKursid { get; set; }
    }
}