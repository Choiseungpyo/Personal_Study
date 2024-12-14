#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

int* solution(int arr[], size_t arr_len) {
    int* answer = (int*)malloc(sizeof(int) * 1000000);
    int answerIndex = 0;

    for (int i = 0; i < arr_len; i++)
    {
        if (answerIndex == 0)
            answer[answerIndex++] = arr[i];
        else if (answer[answerIndex - 1] == arr[i])
            answerIndex--;
        else
            answer[answerIndex++] = arr[i];
    }

    if (!answerIndex)
    {
        realloc(answer, sizeof(int) * 1);
        answer[answerIndex] = -1;
    }
    else
        realloc(answer, sizeof(int) * answerIndex);

    return answer;
}