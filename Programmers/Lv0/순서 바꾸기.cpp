#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

// num_list_len�� �迭 num_list�� �����Դϴ�.
int* solution(int num_list[], size_t num_list_len, int n) {
    int* answer = (int*)malloc(sizeof(int) * num_list_len);
    int answerIndex = 0;

    for (int i = n; answerIndex < num_list_len; i++)
    {
        if (i == num_list_len)
            i = 0;
        answer[answerIndex++] = num_list[i];
    }

    return answer;
}