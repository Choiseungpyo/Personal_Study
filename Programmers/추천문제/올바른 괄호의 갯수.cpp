#include <iostream>
using namespace std;

void dfs(int open, int close, int n, int& answer) {
    if (open == n && close == n) {
        answer++;
        return;
    }

    if (open < n)
        dfs(open + 1, close, n, answer);

    if (close < open)
        dfs(open, close + 1, n, answer);
}

int solution(int n) {
    int answer = 0;
    dfs(0, 0, n, answer);
    return answer;
}