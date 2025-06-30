#include <string>
#include <vector>
#include <algorithm>

using namespace std;

string solution(string X, string Y) {
    string answer = "";
    vector<int> x_count(10, 0), y_count(10, 0);

    for (char c : X)
        x_count[c - '0']++;
    for (char c : Y)
        y_count[c - '0']++;

    for (int i = 9; i >= 0; i--) {
        int common_count = min(x_count[i], y_count[i]);
        if (common_count > 0)
            answer.append(common_count, '0' + i);
    }

    if (answer.empty())
        return "-1";
    if (answer[0] == '0')
        return "0";
    return answer;
}