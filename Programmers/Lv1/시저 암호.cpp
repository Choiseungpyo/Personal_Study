#include <string>

using namespace std;

string solution(string s, int n) {
    for (int i = 0; i < s.length(); i++)
    {
        if (s[i] == ' ')
            continue;

        int c = s[i];
        if (isupper(c)) {
            c = s[i] + n;
            if (c > 'Z') c -= 26;
        }
        else
        {
            c = s[i] + n;
            if (c > 'z') c -= 26;
        }
        s[i] = c;
    }

    return s;
}