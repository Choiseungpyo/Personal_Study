#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

int* solution(int n, int slicer[], size_t slicer_len, int num_list[], size_t num_list_len) {
    int startIndex = 0;
    int endIndex = 0;
    int inc = 1;

    switch (n)
    {
    case 1:
        startIndex = 0;
        endIndex = slicer[1];
        break;

    case 2:
        startIndex = slicer[0];
        endIndex = num_list_len - 1;
        break;

    case 3:
        startIndex = slicer[0];
        endIndex = slicer[1];
        break;

    case 4:
        startIndex = slicer[0];
        endIndex = slicer[1];
        inc = slicer[2];
        break;

    default:
        break;
    }

    int answerSize = inc != 1 ? (endIndex - startIndex + 1) / inc + 1 : endIndex - startIndex + 1;
    int* answer = (int*)malloc(sizeof(int) * answerSize);
    int answerIndex = 0;
    for (int i = startIndex; i <= endIndex; i += inc)
        answer[answerIndex++] = num_list[i];

    return answer;
}