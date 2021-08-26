/************************************************************
    > File Name: quick_select.cpp
    > Author: huguang
    > Mail: hug@haizeix.com
    > Created Time: ��  5/27 03:35:26 2020
 ************************************************************/

#include <iostream>
#include <cstdio>
#include <cstdlib>
#include <queue>
#include <stack>
#include <algorithm>
#include <string>
#include <map>
#include <set>
#include <vector>
using namespace std;

// arr  : ����������
// l--r : ����������
// k : ������Ԫ�ص�����
// �� arr ����� l �� r �����ڣ���������Ϊ k ��Ԫ��
int quick_select(int* arr, int l, int r, int k) {
    // ����ѡȡ��׼ֵ����� partition ����
    int x = l, y = r, z = arr[l];
    while (x < y) {
        while (x < y && arr[y] >= z) --y;
        if (x < y) arr[x++] = arr[y];
        while (x < y && arr[x] <= z) ++x;
        if (x < y) arr[y--] = arr[x];
    }
    arr[x] = z;
    // ind Ϊ��ǰ��׼ֵ������
    // �û�׼ֵ�������� k ���Ƚ�
    // �����ȣ���Ϊ��׼ֵ
    // ��� ind > k����ǰ�벿�ֲ��������� k λ��Ԫ��
    // ��� ind < k, �ں�벿�ֲ��������� k - ind λ��Ԫ��
    int ind = x - l + 1;
    if (ind == k) return arr[x];
    if (ind > k) return quick_select(arr, l, x - 1, k);
    return quick_select(arr, x + 1, r, k - ind);
}

int main() {
    int n, a[100];
    printf("������Ԫ������:");
    scanf_s("%d", &n);
    printf("������ %d ��Ԫ�ص�ֵ:\n", n);
    for (int i = 0; i < n; i++) {
        scanf_s("%d", a + i);
    }
    printf("\n���½���������Կ���ѡ���㷨�Ľ��\n");
    for (int i = 1; i <= n; i++) {
        printf("������ %d λ��Ԫ�أ�%d\n", i, quick_select(a, 0, n - 1, i));
    }
    return 0;
}
