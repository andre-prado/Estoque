using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "The atribute {0} must have a name.")]
        public string Name { get; set; }
        [Range(0.00, 1000000.0, ErrorMessage = "The attribute {0} must be greater than {1} and lass than {2}.")]
        public double Price { get; set; }
        [Range(0, 10000, ErrorMessage = "The attribute {0} must be greater than {1} and lass than {2}.")]
        public int Quantity { get; set; }
        [MaxLength(2000, ErrorMessage = "The attribute {0} must be lass than {1}.")]
        public string Description { get; set; }
    }
}
