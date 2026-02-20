#include <string>
#include <vector>

using namespace std;

int solution(string A, string B) {
    int answer = 0;
    int n = A.size();

    for (; answer < n; ++answer) {
        if (A == B)   break;

        char c = A.back();
        A.pop_back();
        A = c + A;
    }

    return answer == n ? -1 : answer;
}