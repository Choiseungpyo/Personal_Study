#include <string>
#include <vector>
#include <unordered_map>

using namespace std;

int solution(vector<string> strArr) {
    int maxCnt = 0;
    unordered_map<int, int> cntMap;

    for (const auto& str : strArr)
    {
        int cnt = ++cntMap[str.size()];
        if (cnt > maxCnt)   maxCnt = cnt;
    }

    return maxCnt;
}