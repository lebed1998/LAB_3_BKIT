using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_2
{
    class Square : Figure, IPrint
    {
        double height_2;

        public Square(double hg)
        {
            this.height_2 = hg;
            this.Type = "Квадрат";
        }

        public override double Area()
        {
            double result = this.height_2 * this.height_2;
            return result;
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}