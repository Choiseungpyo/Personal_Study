#include <string>
#include <vector>
#include <sstream>
using namespace std;

vector<string> solution(vector<string> quiz) {
    vector<string> answer;

    for (const string& q : quiz) {
        stringstream ss(q);

        int x, y, z;
        char o;
        char e;

        ss >> x >> o >> y >> e >> z;

        int value = x + y;
        if (o == '-') value = x - y;

        string result = "O";
        if (value != z)  result = "X";

        answer.push_back(result);
    }

    return answer;
}