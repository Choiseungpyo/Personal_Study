#include <string>
#include <vector>
#include <unordered_map>

using namespace std;

vector<int> solution(vector<string> name, vector<int> yearning, vector<vector<string>> photo) {
    vector<int> answer;
    unordered_map<string, int> yearningMap;

    for (int i = 0; i < name.size(); ++i)
        yearningMap[name[i]] = yearning[i];

    for (const auto& p : photo)
    {
        int score = 0;
        for (const auto& n : p)
        {
            auto it = yearningMap.find(n);
            if (it != yearningMap.end())
                score += it->second;
        }
        answer.push_back(score);
    }

    return answer;
}