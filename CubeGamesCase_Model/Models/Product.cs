using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeGamesCase_Model.Models
{
   public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string ProductColor { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        [Required]
        public int ProductStock { get; set; }
        [NotMapped] // İndirimli fiyat database 'e yansıtmamak için kullanıldı.
        public double ProductDiscount { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
