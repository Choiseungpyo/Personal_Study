#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

// num_list_len은 배열 num_list의 길이입니다.
int* solution(int num_list[], size_t num_list_len, int n) {
    int size = num_list_len - n + 1;
    int* answer = (int*)malloc(sizeof(int) * size);

    for (int i = 0; i < size; i++)
        answer[i] = num_list[n + i - 1];

    return answer;
}