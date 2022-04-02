using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Models
{
    public class Catagory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Displayorder { get; set; }
    }
}
