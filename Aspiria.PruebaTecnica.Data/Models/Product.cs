using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aspiria.PruebaTecnica.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50),Required]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Range(0,100)]
        public int AgeConstraing { get; set; }
        [MaxLength(50),Required]
        public string Company { get; set; }
        [Range(0.0,1000.00),Required]
        public decimal Price { get; set; }
    }
}
