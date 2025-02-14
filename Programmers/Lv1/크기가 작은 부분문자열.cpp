#include <string>
#include <vector>

using namespace std;

int solution(string t, string p) {
    int answer = 0;
    int cnt = t.length() - p.length();

    for (int i = 0; i <= cnt; i++)
    {
        if (t.substr(i, p.length()) <= p)
            answer++;
    }

    return answer;
}