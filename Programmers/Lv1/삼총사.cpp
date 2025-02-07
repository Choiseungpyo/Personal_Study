#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

// number_len은 배열 number의 길이입니다.
int solution(int number[], size_t number_len) {
    int answer = 0;

    for (int a = 0; a < number_len - 2; a++)
    {
        for (int b = a + 1; b < number_len - 1; b++)
        {
            for (int c = b + 1; c < number_len; c++)
            {
                if (number[a] + number[b] + number[c] == 0)
                    answer++;
            }
        }
    }

    return answer;
}