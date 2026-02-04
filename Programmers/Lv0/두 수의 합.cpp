#include <string>
#include <algorithm>

using namespace std;

string solution(string a, string b) {
    string answer;
    answer.reserve(max(a.size(), b.size()) + 1);
    int i = (int)a.size() - 1;
    int j = (int)b.size() - 1;
    int carry = 0;

    while (i >= 0 || j >= 0 || carry) {
        int sum = carry;

        if (i >= 0) sum += (a[i--] - '0');
        if (j >= 0) sum += (b[j--] - '0');

        answer.push_back(char('0' + (sum % 10)));
        carry = sum / 10;
    }

    reverse(answer.begin(), answer.end());
    return answer;
}