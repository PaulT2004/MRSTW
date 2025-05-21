using MRSTW.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSTW.Domain.Entities.Event
{
     internal class EventDBContext : DbContext
     {
          public EventDBContext() : base("name=MRSTW")
          {
          }

          public DbSet<EventDBTable> Events { get; set; }
     }
}

