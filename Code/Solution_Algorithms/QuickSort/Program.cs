using System;
using System.Collections.Generic;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> arr = new List<int> { 8, 3, 10, 2, 7, 6, 9, 12 };
            int n = arr.Count - 1;

            Console.WriteLine("数据源：");
            for (int i = 0; i <= arr.Count - 1; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");

            QuickSort(arr, 0, arr.Count - 1, n);

            Console.WriteLine("\n排序结果：");
            for (int i = 0; i <= arr.Count - 1; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.Write("\n");
        }

        /// <summary>
        /// 快速排序：对 arr 中 l 到 r 位进行排序
        /// </summary>
        /// <param name="arr">待排序数组</param>
        /// <param name="l">待排序区间起始坐标</param>
        /// <param name="r">待排序区间结束坐标</param>
        /// <param name="n">数组元素的数量</param>
        private static void QuickSort(IList<int> arr, int l, int r, int n)
        {
            // 递归的边界条件是区间中只有一个元素
            // x  : 记录从前向后扫描的位置
            // y  : 记录从后向前扫描的位置
            // z  : 基准值，选择待排序区间的第一个元素
            // while 循环中是 partition 过程
            // 每一轮，先从后向前扫，再从前向后扫
            if (l >= r) return;
            int x = l, y = r, z = arr[l];
            while (x < y)
            {
                while (x < y && arr[y] >= z) --y;
                if (x < y) arr[x++] = arr[y];
                while (x < y && arr[x] <= z) ++x;
                if (x < y) arr[y--] = arr[x];
            }

            // 将基准值 z 放入其正确位置数组的 x 位
            // 其实，此时 x==y，所以写成 arr[y] = z 也行
            // 再分别对左右区间，进行快速排序
            arr[x] = z;
            Output(arr, l, x, r, n);
            QuickSort(arr, l, x - 1, n);
            QuickSort(arr, x + 1, r, n);
        }

        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="arr">排序数组</param>
        /// <param name="l">待排序区间起始坐标</param>
        /// <param name="x">记录从前向后扫描的位置</param>
        /// <param name="r">待排序区间结束坐标</param>
        /// <param name="n">数组元素的数量</param>
        private static void Output(IList<int> arr, int l, int x, int r, int n)
        {
            Console.Write($"\n待排序区间范围 [{l}, {r}]\n");
            Console.Write($"基准值：{arr[x]}\n");

            int cnt = 1;
            for (int i = 0; i < x; i++)
            {
                //cnt += sprintf(str, "%d ", arr[i]); // C++ 中 sprintf 函数返回字符串的长度
                cnt += (arr[i] + " ").Length;
            }

            for (int i = 0; i < l; i++) Console.Write(arr[i] + " ");
            Console.Write("[");
            for (int i = l; i <= r; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.Write("]");
            for (int i = r + 1; i <= n; i++) Console.Write(arr[i] + " ");
            Console.Write("\n");
            for (int i = 0; i < cnt; i++) Console.Write(" ");
            Console.Write("^\n");
            for (int i = 0; i < cnt; i++) Console.Write(" ");
            Console.Write("|\n");
            Console.Write("\n");
            Console.Write("按回车继续...\n");
            Console.ReadLine();
        }
    }
}
