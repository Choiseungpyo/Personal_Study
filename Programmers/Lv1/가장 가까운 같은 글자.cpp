#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

int* solution(const char* s) {
    int n = strlen(s);
    int* answer = (int*)malloc(sizeof(int) * n);

    for (int i = 0; i < n; i++)
    {
        answer[i] = -1;

        for (int a = i - 1; a >= 0; a--)
        {
            if (s[i] != s[a])
                continue;

            answer[i] = i - a;
            break;
        }
    }
    return answer;
}