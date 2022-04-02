using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Models
{
    public class PaymentDeatails
    {
        [Key]
        public int PaymentDetailsId { set; get; }
        public string CardOwnName { set; get; }
        public string CardNumber { get; set; }
        public string Expiredate { get; set; }
        public string SecurityCode { get; set; }
    }
}
