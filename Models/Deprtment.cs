using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Models
{
    public class Deprtment
    {
        [Key]
        public int deprtId { get; set; }
        public string deprtName { get; set; }
    }
}
