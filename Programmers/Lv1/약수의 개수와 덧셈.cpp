#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <math.h>

int solution(int left, int right) {
    int answer = 0;
    int cnt;

    for (int i = left; i <= right; i++)
    {
        cnt = 0;
        for (int a = 1; a <= i; a++)
        {
            if (i % a == 0)
                cnt++;
        }

        if (cnt % 2 == 0)
            answer += i;
        else
            answer -= i;
    }

    return answer;
}