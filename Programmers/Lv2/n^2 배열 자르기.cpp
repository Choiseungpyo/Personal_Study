#include <vector>
#include <algorithm>
using namespace std;

vector<int> solution(int n, long long left, long long right) {
    vector<int> answer;
    answer.reserve(right - left + 1);

    for (long long i = left; i <= right; ++i) {
        answer.push_back((int)(max(i / n, i % n) + 1));
    }

    return answer;
}