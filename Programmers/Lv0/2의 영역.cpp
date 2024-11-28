#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

// arr_len은 배열 arr의 길이입니다.
int* solution(int arr[], size_t arr_len) {
    int* answer = (int*)malloc(sizeof(int) * arr_len);
    int answerIndex = 0;
    int start2Index = -1;
    int end2Index = -1;
    answer[0] = -1;

    for (int i = 0; i < arr_len; i++)
    {
        if (arr[i] == 2)
        {
            if (start2Index == -1)
            {
                start2Index = i;
                end2Index = i;
            }
            else
                end2Index = i;
        }

        if (start2Index != -1)
            answer[answerIndex++] = arr[i];
    }

    realloc(answer, sizeof(int) * (end2Index - start2Index + 1));

    return answer;
}