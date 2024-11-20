#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>
#define SIZE 52

// �Ķ���ͷ� �־����� ���ڿ��� const�� �־����ϴ�. �����Ϸ��� ���ڿ��� �����ؼ� ����ϼ���.
int* solution(const char* my_string) {
    int* answer = (int*)malloc(sizeof(int) * SIZE);
    memset(answer, 0, SIZE);
    for (int i = 0; my_string[i] != 0; i++)
    {
        if (my_string[i] >= 'a')
            answer[SIZE / 2 + my_string[i] - 'a']++;
        else
            answer[my_string[i] - 'A']++;
    }
    return answer;
}