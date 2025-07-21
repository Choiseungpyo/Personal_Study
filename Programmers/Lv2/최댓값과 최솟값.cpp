#include <string>
#include <sstream>
#include <climits>
#include <algorithm>
using namespace std;

string solution(string s) {
    stringstream ss(s);
    string token;

    int minVal = INT_MAX;
    int maxVal = INT_MIN;

    while (ss >> token) {
        int num = stoi(token);
        minVal = min(minVal, num);
        maxVal = max(maxVal, num);
    }

    return to_string(minVal) + " " + to_string(maxVal);
}