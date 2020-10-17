using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrapezeLib;

namespace TrapezeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Trapeze trapeze = CreateTrapeze();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1.Calculate the side lengths of a trapezoid");
                Console.WriteLine("2.Calculate the area of ​​a trapezoid");
                Console.WriteLine("3.Calculate the perimeter of a trapezoid");
                Console.WriteLine("4.Check if point belongs to trapezoid");
                Console.WriteLine("5.Create a new trapezoid");
                Console.WriteLine("Press the Enter key to exit");
                int n;
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    break;
                }
                switch (n)
                {
                    case 1:
                        Console.WriteLine("Side lengths of trapezoid");
                        int i = 1;
                        foreach (double side in trapeze.FindSidesLen())
                        {
                            Console.WriteLine("Party number" + Convert.ToString(i) + " = " + Convert.ToString(side));
                            i += 1;
                        }
                        break;
                    case 2:
                        Console.WriteLine("The area of ​​the trapezoid is " + trapeze.FindSquare());
                        break;
                    case 3:
                        Console.WriteLine("The perimeter of the trapezoid is " + trapeze.FindPerimeter());
                        break;
                    case 4:
                        Console.WriteLine("Enter point x and y coordinates");
                        double x, y;
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Enter the x coordinate");
                                x = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Enter y coordinate");
                                y = Convert.ToDouble(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("You entered incorrect values");
                            }
                        }
                        if (trapeze.IsPoint(x, y))
                            Console.WriteLine("Dot " + Convert.ToString(x) + "; " + Convert.ToString(y) + " belongs to the trapezoid");
                        else
                            Console.WriteLine("Dot " + Convert.ToString(x) + "; " + Convert.ToString(y) + " does not belong to a trapezoid");
                        break;
                    case 5:
                        trapeze = CreateTrapeze();
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
        }
        static Trapeze CreateTrapeze()
        {
            Console.WriteLine("Create a curved trapezoid bounded by the OX axis and sin function");
            Console.WriteLine("Enter the boundaries of the trapezoid (x1, x2)");
            Trapeze trapeze;
            double x1, x2;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the left border of the trapezoid x1");
                    x1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter the right border of the trapezoid x2");
                    x2 = Convert.ToDouble(Console.ReadLine());
                    trapeze = new Trapeze(x1, x2);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You entered incorrect values");
                }
                catch (Exception)
                {
                    Console.WriteLine("This trapezoid does not exist");
                }
            }
            return trapeze;
        }
    }
}
