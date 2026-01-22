#include <string>
#include <vector>

using namespace std;

vector<int> solution(int l, int r) {
    vector<int> answer;

    for (; l <= r; ++l)
    {
        bool isTrue = true;
        string s = to_string(l);

        for (auto c : s)
        {
            if (c != '5' and c != '0')
            {
                isTrue = false;
                break;
            }
        }

        if (isTrue)
            answer.push_back(l);
    }

    if (answer.size() == 0)
        answer.push_back(-1);

    return answer;
}