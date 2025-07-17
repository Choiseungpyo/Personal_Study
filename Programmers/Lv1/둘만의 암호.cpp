#include <string>
#include <unordered_set>
using namespace std;

string solution(string s, string skip, int index) {
    string answer = "";
    unordered_set<char> skipSet(skip.begin(), skip.end());

    for (char c : s) {
        int cnt = 0;
        char nextChar = c;

        while (cnt < index) {
            if (++nextChar > 'z')
                nextChar = 'a';

            if (skipSet.find(nextChar) == skipSet.end())
                cnt++;
        }

        answer += nextChar;
    }

    return answer;
}