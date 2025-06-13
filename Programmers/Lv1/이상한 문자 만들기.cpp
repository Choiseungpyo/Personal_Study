#include <string>
using namespace std;

string solution(string s) {
    int k = 0;

    for (int i = 0; i < s.size(); i++)
    {
        if (s[i] == ' ')
        {
            k = 0;
            continue;
        }

        if (k++ % 2 == 0)
        {
            if (islower(s[i]))
                s[i] = 'A' + s[i] - 'a';
        }
        else
        {
            if (isupper(s[i]))
                s[i] = 'a' + s[i] - 'A';
        }
    }

    return s;
}