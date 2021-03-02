using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入第一个数字");
            int a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("请输入运算符");
            string s = Console.ReadLine();
            Console.WriteLine("请输入第二个数字");
            int b = Int32.Parse(Console.ReadLine());
            int result = 0;
            switch (s)
            {
                case "+" : result = a + b;
                    break;
                case "-": result = a - b;
                    break;
                case "*": result = a * b;
                    break;
                case "/": result = a / b;
                    break;
                default:
                    break;
            }
            Console.WriteLine($"运算结果为{result}");
        }
    }
}
