using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PressYourLuck.Models
{
    public class Audit
    {
        
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public double Amount { get; set; }
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public AuditType Type { get; set; }



    }
}
