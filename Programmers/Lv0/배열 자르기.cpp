#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

int* solution(int numbers[], size_t numbers_len, int num1, int num2) {
    int size = num2 - num1 + 1;
    int* answer = (int*)malloc(sizeof(int) * size);

    for (int i = 0; i < size; i++)
        answer[i] = numbers[num1 + i];

    return answer;
}