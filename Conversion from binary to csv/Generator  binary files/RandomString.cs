﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator__binary_files
{
    class RandomString
    {

        // заполняем столбец коментариев случайными значениями

        Random r = new Random();

        string sumString = "";
        int s = 0;
        int z = 0;
        int t = 0;
        public string ArrayRand()
        {
            s = r.Next(0, 6);
            t = r.Next(-1000, 0);
            z = r.Next(0, 10000);

            if (s == 0)
            { sumString = "   trade:Sell   result:Profit     " + "   +" + z + " $"; }
            else if (s == 1)
            { sumString = "   trade:Sell   result:Loss           " + t + " $"; }
            else if (s == 2)
            { sumString = "   trade:Bay    result:Profit     " + "  +" + z + " $"; }
            else if (s == 3)
            { sumString = "   trade:Bay    result:Loss          " + t + " $"; }
            else if (s == 4)
            { sumString = "   trade:Bay    result:StopLoss  " + t + " $"; }
            else if (s == 5)
            { sumString = "   trade:Sell   result:Stoploss  " + t + " $"; }

            else
            { sumString = " - "; }

            return sumString;
        }
   }
}
