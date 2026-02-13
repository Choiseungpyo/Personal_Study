#include <string>
#include <vector>
#include <unordered_map>
using namespace std;

char getType(const unordered_map<char, int>& data, char a, char b) {
    int va = data.at(a);
    int vb = data.at(b);

    if (va == vb) return (a <= b) ? a : b;
    return (va > vb) ? a : b;
}

string solution(vector<string> survey, vector<int> choices) {
    unordered_map<char, int> result = {
        {'R', 0}, {'T', 0}, {'C', 0}, {'F', 0},
        {'J', 0}, {'M', 0}, {'A', 0}, {'N', 0}
    };

    vector<pair<char, char>> types = {
        {'R', 'T'},
        {'C', 'F'},
        {'J', 'M'},
        {'A', 'N'}
    };

    string answer;
    answer.reserve(4);

    for (int i = 0; i < survey.size(); ++i) {
        int score = choices[i] - 4;
        if (score == 0) continue;

        int points = (score < 0) ? -score : score;
        char target = (score < 0) ? survey[i][0] : survey[i][1];

        result[target] += points;
    }

    for (const auto& t : types) {
        answer.push_back(getType(result, t.first, t.second));
    }
    return answer;
}