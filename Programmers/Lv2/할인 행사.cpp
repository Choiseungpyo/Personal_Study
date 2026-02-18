#include <unordered_map>
#include <queue>
#include <string>

using namespace std;

int solution(vector<string> want, vector<int> number, vector<string> discount) {
    int answer = 0;
    int size = want.size();
    unordered_map<string, int> data;
    queue<string> q;

    for (int i = 0; i < size; ++i) {
        auto k = want[i];
        data[k] = number[i];
    }

    for (const auto& d : discount) {
        q.push(d);
        if (--data[d] == 0) size--;

        if (q.size() > 10) {
            auto front = q.front();
            if (data[front]++ == 0)
                size++;
            q.pop();
        }

        if (!size) ++answer;
    }
    return answer;
}