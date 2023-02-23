/*************************************************************************
	> File Name: quick_sort.cpp
	> Author: huguang
	> Mail: hug@haizeix.com
	> Created Time: ��  5/ 8 02:52:17 2020
 ************************************************************************/

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

#define MAX_N 10000

// arr    : �����洢�������Ԫ��
// n      : ����Ԫ������
// output : ��������еĵ�����Ϣ
// DEBUG = 1 ����������Ϣ
// DEBUG = 0 �رյ�����Ϣ
int arr[MAX_N + 5];
int n;
#define DEBUG 1
void output(int, int, int);

// �������򣺶� arr �� l �� r λ��������
// arr : ����������
// l   : ������������ʼ����
// r   : �����������������
void quick_sort(int* arr, int l, int r) {
	// �ݹ�ı߽�������������ֻ��һ��Ԫ��
	// x  : ��¼��ǰ���ɨ���λ��
	// y  : ��¼�Ӻ���ǰɨ���λ��
	// z  : ��׼ֵ��ѡ�����������ĵ�һ��Ԫ��
	// while ѭ������ partition ����
	// ÿһ�֣��ȴӺ���ǰɨ���ٴ�ǰ���ɨ
	if (l >= r) return;
	int x = l, y = r, z = arr[l];
	while (x < y) {
		while (x < y && arr[y] >= z) --y;
		if (x < y) arr[x++] = arr[y];
		while (x < y && arr[x] <= z) ++x;
		if (x < y) arr[y--] = arr[x];
	}

	// ����׼ֵ z ��������ȷλ������� x λ
	// ��ʵ����ʱ x==y������д�� arr[y] = z Ҳ��
	// �ٷֱ���������䣬���п�������
	arr[x] = z;
	output(l, x, r);
	quick_sort(arr, l, x - 1);
	quick_sort(arr, x + 1, r);
	return;
}

/*-----------�����ķָ���----------*/

void output(int l, int x, int r) {
	if (!DEBUG) return;
	printf("\n���������䷶Χ [%d, %d]\n", l, r);
	printf("��׼ֵ��%d\n", arr[x]);

	char str[30];
	int cnt = 1;
	for (int i = 1; i < x; i++) {
		cnt += sprintf_s(str, "%d ", arr[i]);
	}
	for (int i = 1; i < l; i++) printf("%d ", arr[i]);
	printf("[");
	for (int i = l; i <= r; i++) {
		printf("%d ", arr[i]);
	}
	printf("]");
	for (int i = r + 1; i <= n; i++) printf("%d ", arr[i]);
	printf("\n");
	for (int i = 0; i < cnt; i++) printf(" ");
	printf("^\n");
	for (int i = 0; i < cnt; i++) printf(" ");
	printf("|\n");
	printf("\n");
	printf("���س�����...");
	while (getchar() != '\n');
	return;
}

void read_data() {
	printf("������Ԫ��������");
	scanf_s("%d", &n);
	printf("������ %d ��������\n", n);
	for (int i = 1; i <= n; i++) {
		scanf_s("%d", arr + i);
	}
	while (getchar() != '\n');
	return;
}

int main() {
	read_data();
	quick_sort(arr, 1, n);
	for (int i = 1; i <= n; i++) {
		printf("%d ", arr[i]);
	}
	printf("\n");
	return 0;
}
