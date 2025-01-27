#include <string>
#include <iostream>
using namespace std;

bool solution(string s)
{
    bool answer = true;
    int pCnt = 0;
    int yCnt = 0;

    for (int i = 0; i < s.length(); i++)
    {
        if (s[i] >= 'A' && s[i] <= 'Z')
            s[i] = 'a' + s[i] - 'A';

        if (s[i] == 'p')
            pCnt++;
        else if (s[i] == 'y')
            yCnt++;
    }

    return pCnt == yCnt ? true : false;
}