#include <string>
#include <vector>
#include <queue>

using namespace std;

vector<int> solution(int k, vector<int> score) {
    vector<int> answer;
    priority_queue<int, vector<int>, greater<int>> hallOffFame;

    for (int i = 0; i < score.size(); ++i)
    {
        hallOffFame.push(score[i]);
        if (i > k - 1)
            hallOffFame.pop();

        auto min = hallOffFame.top();
        answer.push_back(min);
    }

    return answer;
}