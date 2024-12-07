#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <math.h>
#define MAXEXPONENT 5

int solution(int num_list[], size_t num_list_len) {
    int answer = 0;
    for (int row = 0; row < num_list_len; row++)
    {
        int i;
        for (i = 0; i < MAXEXPONENT; i++)
        {
            if (i == MAXEXPONENT - 1)
                break;

            if (pow(2, i) <= num_list[row] && num_list[row] < pow(2, i + 1))
                break;
        }
        answer += i;
    }
    return answer;
}