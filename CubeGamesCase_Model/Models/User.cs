using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeGamesCase_Model.Models
{
   public class User
    {
        
        public int UserId { get; set; }
        [Required]
        [Column(TypeName="Varchar(20)")]
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
