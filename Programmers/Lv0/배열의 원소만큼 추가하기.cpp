#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <math.h>

// arr_len은 배열 arr의 길이입니다.
int* solution(int arr[], size_t arr_len) {
    int* answer = (int*)malloc(sizeof(int) * pow(100, 100));
    int answerIndex = 0;

    for (int row = 0; row < arr_len; row++)
    {
        for (int col = 0; col < arr[row]; col++)
            answer[answerIndex++] = arr[row];
    }

    realloc(answer, sizeof(int) * answerIndex);

    return answer;
}