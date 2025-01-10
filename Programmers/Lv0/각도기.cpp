#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

int solution(int angle) {
    int answer = 4;

    if (angle < 90)
        answer = 1;
    else if (angle == 90)
        answer = 2;
    else if (angle < 180)
        answer = 3;

    return answer;
}