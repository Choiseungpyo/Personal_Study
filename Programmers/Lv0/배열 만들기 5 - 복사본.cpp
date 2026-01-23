#include <string>
#include <vector>

using namespace std;

vector<int> solution(vector<string> intStrs, int k, int s, int l) {
    vector<int> answer;

    for (const auto& str : intStrs)
    {
        auto numStr = str.substr(s, l);
        auto num = stoi(numStr);

        if (num > k)
            answer.push_back(num);
    }

    return answer;
}
