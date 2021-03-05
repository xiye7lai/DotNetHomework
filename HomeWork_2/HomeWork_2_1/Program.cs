using System;

namespace HomeWork_2_1
{
    class PrimeFactors
    {
        static bool IsPrime(int x)
        {
            for(int i = 2; i * i <= x; i++)
            {
                if (x % i == 0) return false;
            }
            return true;
        }
        static void FindPrime(int x)
        {
            for(int i = 2; i <= x; i++)
            {
                if (x % i == 0&&IsPrime(i)) Console.Write(i + " ");
            }
        }
        static void Main(string[] args)
        {
            int target;
            Console.WriteLine("请输入整数");
            try
            {
                target = int.Parse(Console.ReadLine());
                FindPrime(target);
            }
            catch (Exception)
            {
                Console.WriteLine("输入类型错误");
            }
        }
    }
}
