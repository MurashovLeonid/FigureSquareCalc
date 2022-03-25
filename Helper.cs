using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureSquareCalc
{
    public static class Helper
    {
        public static void SidesSwap<T>(ref T firstValude, ref T secondValue)
        {
            T buffer = firstValude;
            firstValude = secondValue;
            secondValue = buffer;
        }

    }
}
