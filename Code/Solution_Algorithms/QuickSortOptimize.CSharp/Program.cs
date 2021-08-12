using System;
using System.Collections.Generic;

namespace QuickSortOptimize.CSharp
{
    /// <summary>
    /// 快速排序（优化版）
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> arr = new List<int> { 8, 3, 10, 2, 7, 6, 9, 12 };
            int n = arr.Count - 1;

            QuickSortOld(arr, 0, n);

            Console.WriteLine("\n排序结果：");
            for (int i = 0; i <= arr.Count - 1; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.ReadLine();


            arr = new List<int> { 8, 3, 10, 2, 7, 6, 9, 12 };

            QuickSortNew(arr, 0, n);

            Console.WriteLine("\n排序结果：");
            for (int i = 0; i <= arr.Count - 1; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.ReadLine();
        }

        static void QuickSortOld(IList<int> arr, int l, int r)
        {
            if (l >= r) return;
            int x = l, y = r, z = arr[l];
            while (x < y)
            {
                while (x < y && arr[y] >= z) --y;
                if (x < y) arr[x++] = arr[y];
                while (x < y && arr[x] <= z) ++x;
                if (x < y) arr[y--] = arr[x];
            }
            arr[x] = z;
            QuickSortOld(arr, l, x - 1);
            QuickSortOld(arr, x + 1, r);
        }

        static void QuickSortNew(IList<int> arr, int l, int r)
        {
            while (l < r)
            {
                int x = l, y = r, z = SelectValue(arr[l], arr[r], arr[(l + r) >> 1]);
                do
                {
                    while (arr[x] < z) ++x;
                    while (arr[y] > z) --y;
                    if (x <= y)
                    {
                        arr[x] = arr[x] ^ arr[y];
                        arr[y] = arr[x] ^ arr[y];
                        arr[x] = arr[x] ^ arr[y];
                        x++;
                        y--;
                    }
                } while (x <= y);
                QuickSortNew(arr, x, r);
                r = y;
            }
        }

        static int SelectValue(int a, int b, int c)
        {
            if (a > b)
            {
                a = a ^ b;
                b = a ^ b;
                a = a ^ b;
                //(a, b) = (b, a);
            }

            if (a > c)
            {
                a = a ^ c;
                c = a ^ c;
                a = a ^ c;
                //(a, c) = (c, a);
            }

            if (b > c)
            {
                b = b ^ c;
                c = b ^ c;
                b = b ^ c;
                //(b, c) = (c, b);
            }

            return b;
        }
    }
}
