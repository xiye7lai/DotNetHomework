using System;

namespace HomeWork_2_3
{
    class WritePrime
    {
        static void Main(string[] args)
        {
            bool[] symbol = new bool[105];
            for (int i = 2; i <= 10; i++)
            {
                for (int j = 2; j <= 100; j++)
                {
                    if (j % i == 0 && j != i) symbol[j] = true;
                }
            }
            for (int i = 2; i <= 100; i++)
            {
                if (!symbol[i]) Console.WriteLine(i);
            }
        }
    }
}
