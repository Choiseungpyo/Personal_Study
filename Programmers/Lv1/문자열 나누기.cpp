#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

// �Ķ���ͷ� �־����� ���ڿ��� const�� �־����ϴ�. �����Ϸ��� ���ڿ��� �����ؼ� ����ϼ���.
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
