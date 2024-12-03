#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

// num_list_len은 배열 num_list의 길이입니다.
int solution(int num_list[], size_t num_list_len) {
    int oddSum = 0;
    int evenSum = 0;

    for (int i = 0; i < num_list_len; i++)
    {
        if (i % 2 == 0)
            evenSum += num_list[i];
        else
            oddSum += num_list[i];
    }

    return oddSum > evenSum ? oddSum : evenSum;
}