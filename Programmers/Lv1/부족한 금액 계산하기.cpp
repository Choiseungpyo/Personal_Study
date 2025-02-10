#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

long long solution(int price, int money, int count) {
    long long answer = money;

    for (int i = 1; i <= count; i++)
        answer -= price * i;

    if (answer < 0)
        return -answer;
    return 0;
}
