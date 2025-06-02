#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

// 파라미터로 주어지는 문자열은 const로 주어집니다. 변경하려면 문자열을 복사해서 사용하세요.
int solution(const char* s) {
    int n = strlen(s);
    int answer = 0;
    int sameCnt = 0;
    int diffCnt = 0;
    char x = s[0];

    for (int i = 0; i < n; i++)
    {
        if (sameCnt == diffCnt)
        {
            x = s[i];
            sameCnt = 0;
            diffCnt = 0;
        }

        if (s[i] == x)
            sameCnt++;
        else
            diffCnt++;

        if (sameCnt == diffCnt || i == n - 1)
            answer++;
    }

    return answer;
}
