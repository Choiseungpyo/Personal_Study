#include <string>
#include <vector>
#include <algorithm>
using namespace std;

vector<string> solution(vector<string> strArr) {
    for (int i = 0; i < strArr.size(); ++i)
    {
        auto str = strArr[i];

        if (i % 2)
            transform(str.begin(), str.end(), str.begin(), ::toupper);
        else
            transform(str.begin(), str.end(), str.begin(), ::tolower);

        strArr[i] = str;
    }

    return strArr;
}