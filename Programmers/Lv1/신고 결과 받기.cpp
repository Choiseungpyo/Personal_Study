#include <string>
#include <vector>
#include <unordered_map>
#include <unordered_set>

using namespace std;

vector<int> solution(vector<string> id_list, vector<string> report, int k) {
    int n = id_list.size();
    unordered_map<string, int> idx;
    idx.reserve(n * 2);
    for (int i = 0; i < n; ++i) {
        idx[id_list[i]] = i;
    }

    vector<unordered_set<int>> data(n);
    for (const string& r : report) {
        size_t pos = r.find(' ');
        int a = idx[r.substr(0, pos)];
        int b = idx[r.substr(pos + 1)];
        data[b].insert(a);
    }

    vector<int> answer(n, 0);
    for (int i = 0; i < n; ++i) {
        if (data[i].size() >= k) {
            for (int r : data[i]) {
                ++answer[r];
            }
        }
    }

    return answer;
}