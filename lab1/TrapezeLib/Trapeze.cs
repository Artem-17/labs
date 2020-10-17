using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrapezeLib
{
    /// <summary>
    /// Класс, представляющий собой трапецию, образованную осью OX и функцией синус
    /// </summary>
    public class Trapeze
    {
        /// <summary>
        /// x1 и x2 - границы криволинейной трапеции
        /// </summary>
        private readonly double x1, x2;
        /// <summary>
        /// конструктор класса Трапеция
        /// Если границы переданы в другом порядке, происходит сортировка
        /// </summary>
        /// <param name="x1">Левая граница трапеции</param>
        /// <param name="x2">Правая граница трапеции</param>
        public Trapeze(double x1, double x2)
        {
            this.x1 = Math.Min(x1, x2);
            this.x2 = Math.Max(x1, x2);
            if (!this.IsExist())
            {
                throw new Exception("This trapeze doesn't exist");
            }
        }
        /// <summary>
        /// Метод, проверяющий сущетвует ли трапеция
        /// </summary>
        public bool IsExist()
        {
            if (((Math.Sin(x1) < 0 && Math.Sin(x2) < 0) || (Math.Sin(x1) > 0 && Math.Sin(x2) > 0)) && (x2 - x1) < Math.PI)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Метод, который находит длину стороны трапеции, образованной функцией синус
        /// </summary>
        /// <param name="startX">Левая граница кривой</param>
        /// <param name="finishX">Правая граница кривой</param>
        /// <returns>Длина интегральной кривой</returns>
        private double FindIntegLen()
        {
            double len = 0;
            double dx = (x2 - x1) / 1000;
            double startX = x1;
            double finishX = x1 + dx;
            while (finishX < x2)
            {
                len += Math.Sqrt(Math.Pow(finishX - startX, 2) + Math.Pow(Math.Sin(finishX) - Math.Sin(startX), 2));
                startX += dx;
                finishX += dx;
            }
            return len;
        }
        /// <summary>
        /// Метод, вычисляющий длины сторон трапеции
        /// </summary>
        /// <returns>Длины сторон трапеции</returns>
        public double[] FindSidesLen()
        {
            double[] sides = new double[4];
            sides[0] = x2 - x1;
            sides[1] = Math.Abs(Math.Sin(x2));
            sides[2] = FindIntegLen();
            sides[3] = Math.Abs(Math.Sin(x1));
            return sides;
        }
        /// <summary>
        /// Метод, считающий площадь трапеции по формуле определенного интеграла
        /// </summary>
        /// <returns>Площадь трапеции</returns>
        public double FindSquare()
        {
            return Math.Cos(x1) - Math.Cos(x2);
        }
        /// <summary>
        /// Метод, вычисляющий периметр трапеции
        /// </summary>
        /// <returns>Периметр трапеции</returns>
        public double FindPerimeter()
        {
            double perimeter = 0;
            foreach (double side in this.FindSidesLen())
                perimeter += side;
            return perimeter;
        }
        /// <summary>
        /// Метод, проверяющий, принадлежит ли точка трапеции
        /// </summary>
        /// <param name="x">Координата точки по оси X</param>
        /// <param name="y">Координата точки по оси Y</param>
        public bool IsPoint(double x, double y)
        {
            if (Math.Sin(x1) > 0)
            {
                if (y < 0 || y > Math.Sin(x) || x < x1 || x > x2)
                    return false;
                else
                    return true;
            }
            else
            {
                if (y > 0 || y < Math.Sin(x) || x < x1 || x > x2)
                    return false;
                else
                    return true;
            }
        }
        /// <summary>
        /// Переопределил метод, что бы красиво выводит трапецию
        /// </summary>
        /// <returns>Строковое представление класса трапеция</returns>
        public override string ToString()
        {
            return "It is a trapeze on the interval [" + Convert.ToString(x1) + "; " + Convert.ToString(x2) + "]";
        }
    }
}