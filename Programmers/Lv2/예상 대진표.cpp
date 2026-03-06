#include <cmath>

using namespace std;

int solution(int n, int a, int b)
{
    int answer = 1;
    int cnt = log2(n);

    for (; answer <= cnt; ++answer) {
        a = (a + 1) / 2;
        b = (b + 1) / 2;

        if (a == b) break;
    }

    return answer;
}