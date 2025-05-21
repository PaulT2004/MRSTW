using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSTW.Domain.Entities.Event
{
     public class EventData
     {
          public string Eventname { get; set; }
          public EventType EventType { get; set; }
          public string Username { get; set; }     
          public string Description { get; set; }
          public string EventTime { get; set; }
          public string Location { get; set; }
          public int PlacesTotal { get; set; }
          public int PlacesLeft { get; set; }
          public float Price { get; set; }
          public DateTime Posted { get; set; }
          public DateTime LastUpdated { get; set; }
     }
}
