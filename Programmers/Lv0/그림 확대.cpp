#include <string>
#include <vector>

using namespace std;

vector<string> solution(vector<string> picture, int k) {
    vector<string> answer;

    for (int row = 0; row < picture.size(); ++row) {
        string tmp = "";
        for (int col = 0; col < picture[0].size(); ++col) {
            for (int i = 0; i < k; ++i)
                tmp += picture[row][col];
        }

        for (int j = 0; j < k; ++j) {
            answer.push_back(tmp);
        }
    }

    return answer;
}