#include<string>
#include <queue>

using namespace std;

bool solution(string s)
{
    queue<char> q;

    for (auto c : s)
    {
        if (c == '(')
        {
            q.push(c);
            continue;
        }


        if (q.empty())
            return false;

        q.pop();
    }

    return q.empty() ? true : false;
}