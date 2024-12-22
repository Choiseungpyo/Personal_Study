#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

char** solution(const char* todo_list[], size_t todo_list_len, bool finished[], size_t finished_len) {
    char** answer = (char**)malloc(sizeof(char*) * todo_list_len);
    int answerIndex = 0;

    for (int i = 0; i < todo_list_len; i++)
    {
        if (finished[i])
            continue;

        answer[answerIndex] = (char*)malloc(strlen(todo_list[i]) + 1);
        strcpy(answer[answerIndex++], todo_list[i]);
    }

    return answer;
}