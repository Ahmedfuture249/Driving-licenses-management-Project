using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
   public class clsValdition
    {
        public static bool IsNumber(string input)
        {
            return decimal.TryParse(input, out _);
        }

    }
}
