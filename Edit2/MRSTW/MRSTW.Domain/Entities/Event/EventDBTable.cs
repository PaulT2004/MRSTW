using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSTW.Domain.Entities.Event
{
     internal class EventDBTable
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int EventID { get; set; }

          [Required]
          public EventType EventType { get; set; }

          [Required]
          [Display(Name = "Eventname")]
          [StringLength(50, MinimumLength = 2, ErrorMessage = "Event name must have a name and can have max 50 characters")]
          public string Eventname { get; set; }

          [Required]
          [Display(Name = "Userame")]
          [StringLength(50, MinimumLength = 3)]
          public string Username { get; set; }

          [Required]
          [Display(Name = "Description")]
          [StringLength(200, MinimumLength = 2, ErrorMessage = "Event must have a description and can have max 200 characters")]
          public string Description { get; set; }

          [Required]
          [Display(Name = "EventTime")]
          [StringLength(50, MinimumLength = 2, ErrorMessage = "Event must have a date and can have max 30 characters")]
          public string EventTime { get; set; }

          [Required]
          [Display(Name = "Description")]
          [StringLength(100, MinimumLength = 2, ErrorMessage = "Event must have a location and can have max 100 characters")]
          public string Location { get; set; }

          [Required]
          [Display(Name = "PlacesTotal")]
          public int PlacesTotal { get; set; }

          [Display(Name = "PlacesLeft")]
          public int PlacesLeft { get; set; }

          [Required]
          [Display(Name = "Price")]
          public float Price { get; set; }

          [DataType(DataType.Date)]
          public DateTime Posted { get; set; }

          [DataType(DataType.Date)]
          public DateTime LastUpdated { get; set; }

     }
}
