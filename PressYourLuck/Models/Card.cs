using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PressYourLuck.Models
{
    public class Card
    {
        //"~/images/unknown.png"
        //"~/images/bust.png"
        //"~/images/money.png"

        [Key]
        public int TileIndex { get; set; }
        public double Value { get; set; }
        public bool Visible { get; set; }

        public string GetImagePath()
        {
            string imgFolder = "/images/";
            string imgPath;

            if (!Visible)
            {
                imgPath = "covered.png";
            }
            else
            {
                if (Value > 0.0)
                {
                    imgPath = "win.png";
                }
                else
                {
                    imgPath = "lose.png";
                }
            }
            return imgFolder + imgPath;
        }
    }
}
