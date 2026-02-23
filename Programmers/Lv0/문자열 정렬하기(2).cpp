#include <string>
#include <algorithm>
#include <cctype>

using namespace std;

string solution(string my_string) {
    string answer = my_string;

    transform(answer.begin(), answer.end(), answer.begin(),
        [](unsigned char c) { return (char)tolower(c); });

    sort(answer.begin(), answer.end());
    return answer;
}