#include <string>
#include <vector>
#include <set>
#include <algorithm>
using namespace std;

int solution(vector<string> strs, string t)
{
    set<string> str_set(strs.begin(), strs.end());
    const int INF = 20001;
    int len = t.length();
    vector<int> dy(len + 1, INF);

    dy[len] = 0;
    for (int i = len - 1; i >= 0; --i) {
        string tmp = "";
        for (int j = 0; j < 5 && i + j < len; ++j) {
            tmp += t[i + j];
            if (str_set.find(tmp) != str_set.end())
                dy[i] = min(dy[i], dy[i + j + 1] + 1);
        }
    }

    return dy[0] == INF ? -1 : dy[0];
}