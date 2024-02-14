using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Koolitused.Models
{
    public class GuestDBInitializer : CreateDatabaseIfNotExists<GuestContext> //DropCreateDatabaseAlways<GuestContext>
    {
        protected override void Seed(GuestContext context)
        {
            base.Seed(context);
        }
    }
}