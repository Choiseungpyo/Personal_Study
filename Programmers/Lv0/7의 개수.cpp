#include <string>
#include <vector>
#include <algorithm>

using namespace std;

int solution(vector<int> array) {
    int answer = 0;

    for (auto a : array) {
        auto str = to_string(a);
        answer += count(str.begin(), str.end(), '7');
    }

    return answer;
}