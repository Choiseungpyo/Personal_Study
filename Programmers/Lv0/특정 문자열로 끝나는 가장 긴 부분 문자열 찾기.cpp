#include <string>

using namespace std;

string solution(string myString, string pat) {
    size_t pos = myString.rfind(pat);
    return myString.substr(0, pos + pat.size());
}