using System;
using System.Collections.Generic;

namespace QuickSortOptimize.CSharp
{
    /// <summary>
    /// 快速排序（优化版）
    /// </summary>
    class Program
    {
        private static int n = 10;
        private static int max_N = 1000000;
        private static int[] arr1 = new int[max_N + 5];
        private static int[] arr2 = new int[max_N + 5];

        static void Main(string[] args)
        {
            Console.WriteLine($"测试次数：{n}\n每轮测试数据量：{max_N}");

            for (int i = 1; i <= n; i++)
            {
                Test_One(i);
            }
        }

        static void Test_One(int t)
        {
            var radom = new Random();

            for (int i = 0; i < max_N; i++)
            {
                arr1[i] = radom.Next();
                //a1[i] = i;
                arr2[i] = arr1[i];
            }

            DateTime begin1 = DateTime.Now;
            Quick_Sort_Old(arr1, 0, max_N - 1);
            DateTime end1 = DateTime.Now;
            double time1 = (end1 - begin1).TotalMilliseconds;

            DateTime begin2 = DateTime.Now;
            Quick_Sort_New(arr1, 0, max_N - 1);
            DateTime end2 = DateTime.Now;
            double time2 = (end2 - begin2).TotalMilliseconds;

            Console.WriteLine($"第 {t} 轮测试，Quick_Sort_Old({time1}ms)，Quick_Sort_New({time2}ms)");
        }

        static void Quick_Sort_Old(IList<int> arr, int l, int r)
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
            Quick_Sort_Old(arr, l, x - 1);
            Quick_Sort_Old(arr, x + 1, r);
        }

        static void Quick_Sort_New(IList<int> arr, int l, int r)
        {
            while (l < r)
            {
                int x = l, y = r, z = SelectValue(arr[l], arr[r], arr[(l + r) >> 1]); // 基准值选取优化
                do
                {
                    while (arr[x] < z) ++x;
                    while (arr[y] > z) --y;
                    if (x <= y)
                    {
                        // partition 操作优化
                        arr[x] = arr[x] ^ arr[y];
                        arr[y] = arr[x] ^ arr[y];
                        arr[x] = arr[x] ^ arr[y];
                        x++;
                        y--;
                    }
                } while (x <= y);
                Quick_Sort_New(arr, x, r); // 右侧正常调用递归函数 
                r = y; // 用本层处理左侧的排序（单边递归优化）
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
