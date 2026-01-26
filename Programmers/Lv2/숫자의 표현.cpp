#include <string>
#include <vector>

using namespace std;

int solution(int n) {
    int answer = 0;

    for (int i = 1; i <= n; ++i)
    {
        int v = n;
        for (int j = i; j <= n; ++j)
        {
            v -= j;
            if (v <= 0)
                break;
        }

        if (v == 0)
            ++answer;
    }

    return answer;
}