#include <string>

using namespace std;

int solution(string myString, string pat) {
    for (int i = 0; i < myString.size(); ++i)
    {
        myString[i] = tolower(myString[i]);

        if (i < pat.size())
            pat[i] = tolower(pat[i]);
    }

    return myString.find(pat) == string::npos ? 0 : 1;
}