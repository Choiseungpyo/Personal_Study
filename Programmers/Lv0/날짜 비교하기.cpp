#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

int solution(int date1[], size_t date1_len, int date2[], size_t date2_len) {
    for (int i = 0; i < date1_len; i++)
    {
        if (date1[i] < date2[i])
            return 1;
        else if (date1[i] > date2[i])
            return 0;
    }
    return 0;
}