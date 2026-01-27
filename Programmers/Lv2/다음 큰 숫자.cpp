#include <string>
#include <algorithm>
#include <utility>
using namespace std;

static string toBinary(int n) {
    string s;
    while (n > 0) {
        s.push_back('0' + (n % 2));
        n /= 2;
    }
    reverse(s.begin(), s.end());
    return s;
}

int solution(int n) {
    string s = "0" + toBinary(n);
    int len = (int)s.size();

    for (int i = len - 1; i >= 1; --i) {
        if (s[i - 1] == '0' && s[i] == '1') {
            swap(s[i - 1], s[i]);

            int ones = count(s.begin() + i, s.end(), '1');

            for (int k = i; k < len; ++k) {
                if (k >= len - ones)
                    s[k] = '1';
                else
                    s[k] = '0';
            }
            break;
        }
    }

    return stoi(s, nullptr, 2);
}