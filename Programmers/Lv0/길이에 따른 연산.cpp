#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

// num_list_len�� �迭 num_list�� �����Դϴ�.
int solution(int num_list[], size_t num_list_len) {
    int answer = num_list[0];
    for (int i = 1; i < num_list_len; i++)
    {
        if (num_list_len >= 11)
            answer += num_list[i];
        else
            answer *= num_list[i];
    }
    return answer;
}