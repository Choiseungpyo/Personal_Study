#include <string>
#include <vector>

using namespace std;

int solution(int n) {
    int answer = 0;

    for (int i = 1; i < sqrt(n); ++i) {
        int r = n / i;
        if (n % i == 0)    ++answer;
    }
    answer * 2;

    return answer;
}

int main()
{
    auto tmp = solution(
       20
    );

    return 0;
}