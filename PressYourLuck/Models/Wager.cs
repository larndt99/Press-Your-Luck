using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PressYourLuck.Models
{
    public class Wager
    {
        [Key]
        public string Name { get; set; }
        public double CoinsBet { get; set; }
    }
}
