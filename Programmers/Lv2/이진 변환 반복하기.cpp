#include <string>
#include <vector>
#include <algorithm>

using namespace std;

string toBinary(int x)
{
    string r;
    while (x > 0)
    {
        r.push_back(char('0' + (x % 2)));
        x /= 2;
    }
    reverse(r.begin(), r.end());
    return r;
}

vector<int> solution(string s)
{
    int convertCount = 0;
    int removedZero = 0;

    while (s != "1")
    {
        int countOnes = (int)count(s.begin(), s.end(), '1');
        removedZero += (int)s.size() - countOnes;

        s = toBinary(countOnes);
        ++convertCount;
    }

    return { convertCount, removedZero };
}