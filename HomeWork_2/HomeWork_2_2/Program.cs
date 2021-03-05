using System;

namespace HomeWork_2_2
{
    class ArrayInformation
    {
        static void Main(string[] args)
        {
            int length = 0;
            Console.WriteLine("输入数组长度");
            length = int.Parse(Console.ReadLine());
            int[] a = new int[length];
            Console.WriteLine("输入数组（数字以换行符隔开）");
            for(int i = 0; i < a.Length; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }
            int max = 0, min = int.MaxValue,  sum = 0;
            Array.ForEach(a, temp => { if (temp >= max) max = temp; });
            Array.ForEach(a, temp => { if (temp <= min) min = temp; });
            Array.ForEach(a, temp => sum += temp);
            Console.WriteLine($"最大值为：{max}\n最小值为：{min}\n平均值为: {(double)sum/length}\n数组的和为: {sum}");
        }
    }
}
