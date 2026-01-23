#include <string>
#include <vector>
#include <algorithm>

using namespace std;

vector<string> solution(string my_string) {
    vector<string> answer;

    for (int i = 0; i < my_string.size(); ++i)
    {
        auto str = my_string.substr(i);
        answer.push_back(str);
    }

    sort(answer.begin(), answer.end());

    return answer;
}