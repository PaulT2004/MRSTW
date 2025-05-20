using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MRSTW.Domain.Entities.User
{
     internal class UserDBTable
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int ID { get; set; }

          [Required]
          [Display(Name="Username")]
          [StringLength(50, MinimumLength = 3, ErrorMessage = "Username can be between 3 and 50 characters")]
          public string Username { get; set; }

          [Required]
          [Display(Name = "Password")]
          [StringLength(50, MinimumLength = 8, ErrorMessage = "Password can be between 8 and 50 characters")]
          public string Password { get; set; }

          [Required]
          [Display(Name = "Email")]
          [StringLength(75)]
          public string Email { get; set; }

          [DataType(DataType.Date)]
          public DateTime LastLogin { get; set; }
     }
}
