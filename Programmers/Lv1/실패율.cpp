#include <string>
#include <vector>
#include <algorithm>

using namespace std;

vector<int> solution(int N, vector<int> stages) {
    vector<int> answer;
    vector<pair<int, double>> failureRate(N);
    int challengersNum = (int)stages.size();

    for (int i = 0; i < N; ++i) failureRate[i] = { i + 1, 0.0 };

    for (int s : stages) {
        if (1 <= s && s <= N)   failureRate[s - 1].second += 1.0;
    }

    for (int i = 0; i < N; ++i) {
        double stuck = failureRate[i].second;
        if (challengersNum > 0)   failureRate[i].second = stuck / (double)challengersNum;
        else failureRate[i].second = 0.0;
        challengersNum -= (int)stuck;
    }

    sort(failureRate.begin(), failureRate.end(),
        [](const pair<int, double>& a, const pair<int, double>& b) {
            if (a.second != b.second) return a.second > b.second;
            return a.first < b.first;
        });

    for (const auto& f : failureRate)    answer.push_back(f.first);

    return answer;
}