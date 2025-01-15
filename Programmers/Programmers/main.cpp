#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <math.h>

int solution(int n) {
    int answer = 0;

    for (int i = 1; i < sqrt(n); i++)
    {
        if (n % i == 0)
        {
            answer += i;
            int tmp = n / i;
            if (i != tmp)
                answer += tmp;
        }
    }
    return answer;
}

int main()
{
    const char* players[] = { "mumu", "soe", "poe", "kai", "mine" };
    const char* callings[] = { "kai", "kai", "mine", "mine" };

    int a = solution(12);
    return 0;
}