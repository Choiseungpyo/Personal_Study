#include <string>
#include <vector>

using namespace std;

vector<string> solution(string my_string) {
    vector<string> answer;
    string str = "";

    for (auto it = my_string.begin(); it != my_string.end(); ++it)
    {
        if (it == my_string.end() - 1 && *it != ' ')
        {
            str += *it;
            answer.push_back(str);
        }
        else if (*it != ' ')
        {
            str += *it;
        }
        else if (str != "")
        {
            answer.push_back(str);
            str = "";
        }

    }

    return answer;
}