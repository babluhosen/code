using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Models
{
    public class Branch
    {
      
        public Branch()
        {
            Branchlist = new List<bank>() {
        new bank { BankName = "Datchbangla", BankId = 22 },

       
        };
        }
       
        public int BranchId { get; set; }
       public string BranchCode { get; set; }
        public int BankId { get; set; }
        public  List<bank> Branchlist { get; set; }
    }
}
