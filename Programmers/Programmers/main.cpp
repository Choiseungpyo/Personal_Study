#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

int solution(int numbers[], size_t numbers_len) {
    int answer = 45;

    for (int i = 0; i < numbers_len; i++)
        answer -= numbers[i];

    return answer;
}

int main()
{
    int absolutes[] = { 5,8,4,0,6,7,9 };
    bool signs[] = { false,false,true };
    auto result = solution(absolutes, 7);
    return 0;
}