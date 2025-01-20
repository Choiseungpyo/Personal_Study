#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

char* solution(const char* phone_number) {
    int size = strlen(phone_number);
    char* answer = (char*)malloc(size + 1);
    for (int i = 0; i < size; i++)
    {
        if (i < size - 4)
            answer[i] = '*';
        else
            answer[i] = phone_number[i];
    }
    answer[size] = 0;

    return answer;
}