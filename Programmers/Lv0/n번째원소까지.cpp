#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

// num_list_len�� �迭 num_list�� �����Դϴ�.
int* solution(int num_list[], size_t num_list_len, int n) {
    int* answer = (int*)malloc(sizeof(int) * n);
    for (int i = 0; i < n; i++)
        answer[i] = num_list[i];
    return answer;
}