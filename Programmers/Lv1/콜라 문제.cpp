#include <string>
#include <vector>

using namespace std;

int solution(int a, int b, int n) {
    int answer = 0;

    while (n >= a)
    {
        int cnt = n / a;
        answer += b * cnt;
        n = b * cnt + n % a;
    }

    return answer;
}