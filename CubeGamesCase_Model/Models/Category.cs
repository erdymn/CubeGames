using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeGamesCase_Model.Models
{
   public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
        public List<Product> Product { get; set; }
    }
}
