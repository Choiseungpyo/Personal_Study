#include <string>
#include <vector>

using namespace std;

long long sol(int n) {

}

long long solution(int n) {
    if (n == 0)    return 1;
    else if (n < 0)  return 0;

    long long answer = 0;
    answer = solution(n - 1) + solution(n - 2);

    return answer;
}

int main()
{
    auto tmp = solution(
       3
    );

    return 0;
}