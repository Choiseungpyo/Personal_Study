#include <string>
#include <vector>
#include <unordered_map>

using namespace std;

int solution(string s) {
    int answer = 0;
    unordered_map<string, string> words = {
        {"zero", "0"},
        {"one", "1"},
        {"two", "2"},
        {"three", "3"},
        {"four", "4"},
        {"five", "5"},
        {"six", "6"},
        {"seven", "7"},
        {"eight", "8"},
        {"nine", "9"},
    };

    for (auto [key, value] : words)
    {
        size_t pos = 0;
        while (true)
        {
            pos = s.find(key, pos);
            if (pos == string::npos)
                break;

            s.replace(pos++, key.size(), value);
        }
    }

    return stoi(s);
}