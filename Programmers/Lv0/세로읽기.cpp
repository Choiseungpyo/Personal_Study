#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

// �Ķ���ͷ� �־����� ���ڿ��� const�� �־����ϴ�. �����Ϸ��� ���ڿ��� �����ؼ� ����ϼ���.
char* solution(const char* my_string, int m, int c) {
    int size = strlen(my_string) / m;
    char* answer = (char*)malloc(size + 1);

    for (int i = 0; i < size; i++)
        answer[i] = my_string[m * i + c - 1];

    answer[size] = 0;
    return answer;
}