#include <string>
#include <vector>
#include <cctype>
#include <numeric>
#include <cmath>
using namespace std;

int solution(string dartResult) {
    vector<int> scores;
    int score = 0;

    scores.reserve(3);

    for (auto it = dartResult.begin(); it != dartResult.end(); ++it) {
        char c = *it;

        if (isdigit((unsigned char)c)) {
            score = c - '0';
            if (*(it + 1) == '0') {
                score = 10;
                ++it;
            }
        }
        else if (c == '*') {
            int idx = (int)scores.size() - 1;
            scores[idx] *= 2;
            if (idx > 0) scores[idx - 1] *= 2;
        }
        else if (c == '#') {
            scores.back() *= -1;
        }
        else {
            int p = 1;
            switch (c) {
            case 'S': p = 1; break;
            case 'D': p = 2; break;
            case 'T': p = 3; break;
            }
            scores.push_back(pow(score, p));
        }
    }

    return accumulate(scores.begin(), scores.end(), 0);
}