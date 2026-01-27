#include <string>
#include <vector>

using namespace std;

vector<string> solution(string my_string) {
    vector<string> answer;
    string str;

    for (auto it = my_string.begin(); it != my_string.end(); ++it)
    {
        if (it == my_string.end() - 1)
        {
            str += *it;
            answer.push_back(str);
        }
        else if (*it == ' ')
        {
            answer.push_back(str);
            str = "";
        }
        else
            str += *it;
    }

    return answer;
}