using System;

namespace HomeWork_2_4
{
    class JudgeTMatrix
    {
        static void Main(string[] args)
        {
            int row = 1, column = 1;
            Console.WriteLine("输入矩阵行数");
            row = int.Parse(Console.ReadLine());
            Console.WriteLine("输入矩阵列数");
            column = int.Parse(Console.ReadLine());
            Console.WriteLine("输入矩阵（元素以空格隔开，每一行以换行隔开）");
            int[][] matrix = new int[row][];
            for (int i = 0; i < row; i++)
            {
                matrix[i] = new int[column];
                string value = Console.ReadLine();
                string[] vals = value.Split(" ");
                for (int j = 0; j < column; j++)
                {
                    matrix[i][j] = int.Parse(vals[j]);
                }
            }
            for(int i = 0; i < row-1; i++)
            {
                for (int j = 0; j < column-1; j++)
                {
                    if (matrix[i][j] != matrix[i + 1][j + 1])
                    {
                        Console.WriteLine("False");
                        return;
                    }
                }
            }
            Console.WriteLine("True");
        }
    }
}
