#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

// �Ķ���ͷ� �־����� ���ڿ��� const�� �־����ϴ�. �����Ϸ��� ���ڿ��� �����ؼ� ����ϼ���.
char* solution(int q, int r, const char* code) {
    int size = strlen(code) / q + (strlen(code) % q >= r ? 1 : 0);
    char* answer = (char*)malloc(size + 1);

    for (int i = 0; i < size; i++)
        answer[i] = code[i * q + r];

    answer[size] = 0;
    return answer;
}