using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Models
{
    public class emplyer
    {
        [Key]
       public int empId { get; set; }
        public string empName { get; set; }
        public int deprtId { get; set; }
      
        public Deprtment deprtment { get; set; }
    }
}
