#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

int* solution(const char* myString) {
    int size = strlen(myString);
    int* answer = (int*)malloc(sizeof(int) * size);
    int answerIndex = 0;
    int prvXIndex = -1;

    for (int i = 0; i < size; i++)
    {
        if (myString[i] == 'x')
        {
            answer[answerIndex++] = i - prvXIndex - 1;
            prvXIndex = i;
        }
        if (i == size - 1)
            answer[answerIndex++] = i - prvXIndex;
    }

    realloc(answer, sizeof(int) * answerIndex);

    return answer;
}