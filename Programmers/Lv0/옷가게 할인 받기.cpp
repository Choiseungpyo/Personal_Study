#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

int solution(int price) {
    int answer = price;

    if (price >= 500000)
        answer = price * 0.8f;
    else if (price >= 300000)
        answer = price * 0.9f;
    else if (price >= 100000)
        answer = price * 0.95f;

    return answer;
}