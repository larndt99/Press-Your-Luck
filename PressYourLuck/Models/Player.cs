using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PressYourLuck.Models
{
    public class Player
    {
        [Key]
        public string Name { get; set; }
        public double CoinsTotal { get; set; }
    }
}
