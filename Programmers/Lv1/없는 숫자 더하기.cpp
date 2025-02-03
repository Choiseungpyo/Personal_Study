#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#define NUM 9

int solution(int numbers[], size_t numbers_len) {
    int answer = (1 + NUM) * NUM / 2;

    for (int i = 0; i < numbers_len; i++)
        answer -= numbers[i];

    return answer;
}