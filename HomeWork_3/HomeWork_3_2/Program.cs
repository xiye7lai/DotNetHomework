using System;
using HomoWork_3_1;
namespace HomeWork_3_2
{
    public class Factory
    {
        public static Shape CreateShape(int condition)
        {
            Shape shape = null;
            Random ran = new Random();
            int RandKey1 = ran.Next(100, 999);
            int RandKey2 = ran.Next(100, 999);
            int RandKey3 = ran.Next(100, 999);
            if (condition == 1)
            {
                shape = new Square(RandKey1);
                return shape;
            }
            if (condition == 2)
            {
                shape = new Recangle(RandKey1, RandKey2);
            }
            if (condition == 3)
            {
                shape = new Delta(RandKey1, RandKey2, RandKey3);
            }
            return shape;
        }
    }
    public class Test
    {
        static void Main(string[] args)
        {
            Shape shape = null;
            for (int i = 0; i < 10; i++)
            {
                Random ran = new Random();
                int RandKey = ran.Next(1, 4);
                shape = Factory.CreateShape(RandKey);
                string shapeClass = shape.GetType().Name;
                if (shapeClass == "Delta")
                {
                    Console.WriteLine("创建的形状为三角形");
                    Console.WriteLine($"创建的形状是否合法：{shape.IsLegal()}");
                    Console.WriteLine($"三角形面积为{shape.Area()}");
                }
                if (shapeClass == "Recangle")
                {
                    Console.WriteLine("创建的形状为矩形");
                    Console.WriteLine($"创建的形状是否合法：{shape.IsLegal()}");
                    Console.WriteLine($"矩形面积为{shape.Area()}");
                }
                if (shapeClass == "Square")
                {
                    Console.WriteLine("创建的形状为正方形");
                    Console.WriteLine($"创建的形状是否合法：{shape.IsLegal()}");
                    Console.WriteLine($"正方形面积为{shape.Area()}");
                }
                Console.WriteLine();
            }
        }
    }
}
