#include <string>
#include <vector>
#include <algorithm>

using namespace std;

string solution(string my_string) {
    string answer = "";

    transform(my_string.begin(), my_string.end(), answer.begin(),
        [](unsigned char c) { return (char)tolower(c); });
    sort(answer.begin(), answer.end());

    return answer;
}

int main()
{
    auto tmp = solution(
        "abc1Addfggg4556b", 6
    );

    return 0;
}