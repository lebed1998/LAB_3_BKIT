using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Laba_2
{
    // Абстрактный класс «Геометрическая фигура» 
    abstract class Figure : IComparable
    {
        public string Type
        {
            get
            {
                return this._Type;
            }
            protected set
            {
                this._Type = value;
            }
        }
        string _Type;

        // Вычисление площади фигуры
        public abstract double Area();

        public override string ToString()
        {
            return this._Type + " Площадь =" + this.Area().ToString();
        }

        // Сравнение элементов (для сортировки списка)
        public int CompareTo(object obj)
        {
            Figure p = (Figure)obj;
            if (this.Area() < p.Area()) return -1;
            else if (this.Area() == p.Area()) return 0;
            else return 1;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(3, 4);
            Square square = new Square(5);
            Circle circle = new Circle(10);

            rect.Print();
            square.Print();
            circle.Print();

            ///////////////////////////////////////////////////////////
            Console.WriteLine("\nArrayList");
            ArrayList al = new ArrayList();
            al.Add(circle);
            al.Add(rect);
            al.Add(square);

            al.Sort();
            foreach (var x in al) Console.WriteLine(x);
            //////////////////////////////////////////////////////////
            Console.WriteLine("\nList<Figure>");
            List<Figure> fl = new List<Figure>();
            fl.Add(circle);
            fl.Add(rect);
            fl.Add(square);

            fl.Sort();
            foreach (var x in fl) Console.WriteLine(x);
            //////////////////////////////////////////////////////////
            Console.WriteLine("\nМатрица");
            Matrix<double> cube = new Matrix<double>(3, 3, 3, 0);
            cube[0, 0, 0] = rect.Area();
            cube[1, 1, 1] = square.Area();
            cube[2, 2, 2] = circle.Area();
            Console.WriteLine(cube.ToString());

            //////////////////////////////////////////////////////////
            Console.WriteLine("\nСтек");
            Stack<Figure> stack = new Stack<Figure>();
            stack.Push(rect);
            stack.Push(square);
            stack.Push(circle);

            while (stack.Count > 0)
            {
                Figure f = stack.Pop();
                Console.WriteLine(f);
            }

            Console.ReadLine();
        }
    }
}