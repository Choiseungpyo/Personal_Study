#include <string>
#include <vector>
#include <algorithm>

using namespace std;

vector<string> solution(string myString) {
    vector<string> answer;
    string str = "";

    for (auto it = myString.begin(); it != myString.end(); ++it)
    {
        if (*it != 'x')
        {
            str += *it;
        }

        if ((*it == 'x' || it == myString.end() - 1) && !str.empty())
        {
            answer.push_back(str);
            str.clear();
        }
    }

    sort(answer.begin(), answer.end());

    return answer;
}