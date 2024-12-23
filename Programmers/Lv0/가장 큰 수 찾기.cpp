#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

// array_len은 배열 array의 길이입니다.
int* solution(int array[], size_t array_len) {
    int* answer = (int*)malloc(sizeof(int) * 2);
    answer[0] = array[0];
    answer[1] = 0;

    for (int i = 1; i < array_len; i++)
    {
        if (array[i] > answer[0])
        {
            answer[0] = array[i];
            answer[1] = i;
        }
    }

    return answer;
}