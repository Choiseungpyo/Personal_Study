#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

char* solution(const char* myString) {
    int size = strlen(myString);
    char* answer = (char*)malloc(size + 1);

    for (int i = 0; i < size; i++)
    {
        if ('B' <= myString[i] && myString[i] <= 'Z')
            answer[i] = 'a' + myString[i] - 'A';
        else if (myString[i] == 'a')
            answer[i] = 'A';
        else
            answer[i] = myString[i];
    }
    answer[size] = 0;
    return answer;
}