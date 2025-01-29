#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <math.h>

long long solution(long long n) {
    long long answer = sqrt(n);

    if (answer - int(answer) == 0)
        return (int(answer) + 1) * (int(answer) + 1);
    return -1;
}

int main()
{
    long long s = solution(50000000000000);
    return 0;
}