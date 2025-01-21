#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

char* solution(const char* s) {
    int sSize = strlen(s);
    int answerSize = sSize % 2 == 0 ? 2 : 1;
    char* answer = (char*)malloc(answerSize + 1);

    for (int i = 0; i < answerSize; i++)
        answer[i] = s[answerSize == 1 ? sSize / 2 : sSize / 2 - 1 + i];
    answer[answerSize] = 0;

    return answer;
}