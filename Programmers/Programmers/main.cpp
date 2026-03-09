#include <vector>
#include <algorithm>
using namespace std;

vector<int> solution(int n, long long left, long long right) {
    vector<int> answer;
    answer.reserve(right - left + 1);

    for (int i = left; i <= right; ++i) {
        answer.push_back((max(i / n, i % n) + 1));
    }
        
    return answer;
}

int main()
{
    auto tmp = solution(
       3,2,5
    );

    return 0;
}