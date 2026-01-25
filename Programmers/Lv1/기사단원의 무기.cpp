#include <string>
#include <vector>

using namespace std;

int solution(int number, int limit, int power) {
    int answer = 0;

    for (int i = 1; i <= number; ++i)
    {
        int cnt = 0;
        for (int a = 1; a * a <= i; ++a)
        {
            if (i % a == 0)
            {
                ++cnt;
                int b = i / a;
                if (a != b)
                    ++cnt;
            }
        }

        if (cnt <= limit)
            answer += cnt;
        else
            answer += power;
    }

    return answer;
}