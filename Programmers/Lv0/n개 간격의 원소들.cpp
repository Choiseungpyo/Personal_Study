#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

// num_list_len�� �迭 num_list�� �����Դϴ�.
int* solution(int num_list[], size_t num_list_len, int n) {
    int size = num_list_len / n + num_list_len % n;
    int* answer = (int*)malloc(sizeof(int) * size);
    for (int i = 0; i < size; i++)
        answer[i] = num_list[i * n];
    return answer;
}