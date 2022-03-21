using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Models
{
    public class bank
    {
        [Key]
        public int BankId { get; set; }
        public string BankName { get; set; }
    }
}
