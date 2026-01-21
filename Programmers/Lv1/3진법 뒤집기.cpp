#include <string>
#include <vector>

using namespace std;

int solution(int n) {
    string s;
    while (n > 0) {
        s += char('0' + (n % 3));
        n /= 3;
    }

    return stoi(s, nullptr, 3);
}