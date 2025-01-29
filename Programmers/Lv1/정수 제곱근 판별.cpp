#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <math.h>

long long solution(long long n) {
    double answer = sqrt(n);

    if (answer == (int)answer)
        return (answer + 1) * (answer + 1);
    return -1;
}