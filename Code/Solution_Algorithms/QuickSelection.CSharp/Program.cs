// See https://aka.ms/new-console-template for more information

int n = 0;
int[] a = new int[100];
Console.WriteLine("请输入元素数量:");
n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"\n请输入 {n} 个元素的值:");
for (int i = 0; i < n; i++)
{
    a[i] = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("\n以下结果，均来自快速选择算法的结果");
for (int i = 1; i <= n; i++)
{
    Console.WriteLine($"排名第 {i} 位的元素：{QuickSelect(a, 0, n - 1, i)}");
}

/// <summary>
/// 快速查找算法（Top K）
/// 在 arr 数组的 l 到 r 区间内，查找排名为 k 的元素
/// </summary>
/// <param name="arr">待查找数组</param>
/// <param name="l">待查找区间起始坐标</param>
/// <param name="r">待查找区间结束坐标</param>
/// <param name="k">待查找元素的排名</param>
int QuickSelect(int[] arr, int l, int r, int k)
{
    // 首先选取基准值，完成 partition 操作
    int x = l, y = r, z = arr[l];
    while (x < y)
    {
        while (x < y && arr[y] >= z) --y;
        if (x < y) arr[x++] = arr[y];
        while (x < y && arr[x] <= z) ++x;
        if (x < y) arr[y--] = arr[x];
    }
    arr[x] = z;
    // ind 为当前基准值的排名
    // 用基准值的排名与 k 做比较
    // 如果相等，则为基准值
    // 如果 ind > k，在前半部分查找排名第 k 位的元素
    // 如果 ind < k, 在后半部分查找排名第 k - ind 位的元素
    int ind = x - l + 1;
    if (ind == k) return arr[x];
    if (ind > k) return QuickSelect(arr, l, x - 1, k);
    return QuickSelect(arr, x + 1, r, k - ind);
}