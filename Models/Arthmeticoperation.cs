using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Models
{
    public class Arthmeticoperation
    {
        [Key]
        public int ArthId { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal ItemQuantity { get; set; }
        public decimal Total { get; set; }
    }
}
