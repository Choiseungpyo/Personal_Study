#include <string>
#include <vector>

using namespace std;

vector<string> solution(string myStr) {
    vector<string> answer;
    const string delimiter = "abc";

    size_t delimiterPos = 0;
    size_t startIndex = 0;
    myStr += delimiter[0];

    while (startIndex < myStr.size())
    {
        delimiterPos = myStr.find_first_of(delimiter, delimiterPos);
        if (delimiterPos == string::npos)
            break;

        if (delimiterPos != startIndex)
            answer.emplace_back(myStr, startIndex, delimiterPos - startIndex);

        startIndex = ++delimiterPos;
    }

    if (answer.empty())
        answer.push_back("EMPTY");
    return answer;
}