#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

bool solution(const char* s) {
    int size = strlen(s);
    if (size != 4 && size != 6)
        return false;

    for (int i = 0; i < size; i++)
    {
        if (s[i] < '0' || s[i] > '9')
            return false;
    }

    return true;
}