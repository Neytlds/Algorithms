/*************************************************************************
	> File Name: heap.cpp
	> Author: huguang
	> Mail: hug@haizeix.com
	> Created Time: ��  4/29 21:08:08 2020
 ************************************************************************/

#include <stdio.h>
#include <stdlib.h>

 /*
 * �����һ���С���ѣ���ʾһ�����ȶ���
 * ��������иĳɴ󶥶�
 * */
typedef struct Heap {
	int* data; // �洢���ݵ�����, Ĭ��ÿ��Ԫ�ص����Ͷ�������
	int n;     // ����Ԫ������
	int size;  // �������
} Priority_Queue;

// ��ʼ��һ���������Ϊ size �����ȶ���
Priority_Queue* init(int size) {
	Priority_Queue* q = (Priority_Queue*)malloc(sizeof(Priority_Queue));
	q->data = (int*)malloc(sizeof(int) * size);
	// ���������±�� 1 ��ʼ
	q->data -= 1;
	q->n = 0;
	q->size = size;
	return q;
}

// �ѵ����ϵ�������
// ind ָ��ǰ��Ҫ���ϵ����Ľڵ�
// father ָ�� ind �ĸ��ڵ�
void up_update(Priority_Queue* q, int ind) {
	int father, val;
	while (ind != 1) {
		father = ind / 2;
		if (q->data[father] <= q->data[ind]) break;
		val = q->data[ind];
		q->data[ind] = q->data[father];
		q->data[father] = val;
		ind = father;
	}
	return;
}

// �ѵ����µ�������
// ind ָ��ǰ��Ҫ���µ����Ľڵ�
// temp ָ�������ӽڵ���ֵ��С�Ľڵ�
// ind * 2 <= q->n ˵����ǰ�ڵ㻹���ӽڵ�
void down_update(Priority_Queue* q, int ind) {
	int temp, val;
	while (ind * 2 <= q->n) {
		temp = ind * 2;
		if (temp + 1 <= q->n && q->data[temp + 1] < q->data[temp]) {
			temp = temp + 1;
		}
		if (q->data[ind] <= q->data[temp]) break;
		val = q->data[ind];
		q->data[ind] = q->data[temp];
		q->data[temp] = val;
		ind = temp;
	}
	return;
}

// �����пղ���
int empty(Priority_Queue* q) {
	return q->n == 0;
}

// ��Ӳ���
// �ȷ���Ԫ�أ������ϵ���
int push(Priority_Queue* q, int element) {
	if (q->n == q->size) return 0;
	q->data[++(q->n)] = element;
	up_update(q, q->n);
	return 1;
}

// ���Ӳ���
// �ȸ���Ԫ�أ������µ���
void pop(Priority_Queue* q) {
	if (empty(q)) return;
	q->data[1] = q->data[(q->n)--];
	down_update(q, 1);
	return;
}

// �鿴�Ѷ�Ԫ��
int top(Priority_Queue* q) {
	return q->data[1];
}

// �������ȶ���
void clear(Priority_Queue* q) {
	free(q->data + 1);
	free(q);
	return;
}

//---------------�����ķָ���----------------//

void usage(int* op) {
	printf("���ȶ��нṹѧϰ���������������(0--6)��\n");
	printf("\t0.�鿴����Ԫ�����\n");
	printf("\t1.����Ԫ��\n");
	printf("\t2.�Ƴ�����Ԫ��\n");
	printf("\t3.�鿴����Ԫ��\n");
	printf("\t4.�˳�\n");
	printf("�����������������Ӧ�����֣�");
	scanf_s("%d", op);
	return;
}

void output(Priority_Queue* q) {
	for (int i = 1; i <= q->size; i++) {
		printf("%4d", i);
	}
	printf("\n");
	for (int i = 1; i <= q->size; i++) {
		printf("----");
	}
	printf("\n");
	for (int i = 1; i <= q->n; i++) {
		printf("%4d", q->data[i]);
	}
	for (int i = q->n + 1; i <= q->size; i++) {
		printf("   -");
	}
	printf("\n");
	return;
}


int main() {
	int size, loop = 1;
	printf("�����ʼ��������");
	scanf_s("%d", &size);
	Priority_Queue* q = init(size);
	do {
		int op, val;
		usage(&op);
		switch (op) {
		case 0: output(q); break;
		case 1: {
			printf("������Ҫ��������֣�");
			scanf_s("%d", &val);
			push(q, val);
		} break;
		case 2: pop(q); break;
		case 3: printf("%d\n", top(q)); break;
		case 4: loop = 0; break;
		}
	} while (loop);
	clear(q);
	return 0;
}
