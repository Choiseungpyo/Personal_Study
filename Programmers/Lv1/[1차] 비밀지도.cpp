#include <string>
#include <vector>
#include <algorithm>

using namespace std;

string toBinary(int n, int x)
{
    string result = "";
    while (x > 0) {
        result.push_back(char('0' + x % 2));
        x /= 2;
    }

    result.resize(n, '0');
    return result;
}

vector<string> solution(int n, vector<int> arr1, vector<int> arr2) {
    vector<string> answer;
    for (int i = 0; i < n; ++i) {
        string row = "";
        auto row1 = toBinary(n, arr1[i]);
        auto row2 = toBinary(n, arr2[i]);

        for (int k = 0; k < n; ++k) {
            if (row1[k] == '1' || row2[k] == '1') row.push_back('#');
            else row.push_back(' ');
        }

        reverse(row.begin(), row.end());
        answer.push_back(row);
    }

    return answer;
}