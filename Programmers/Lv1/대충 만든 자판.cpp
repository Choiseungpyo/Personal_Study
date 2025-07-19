#include <string>
#include <vector>
#include <unordered_map>
#include <algorithm>

using namespace std;

vector<int> solution(vector<string> keymap, vector<string> targets) {
    unordered_map<char, int> minPress;
    vector<int> answer;

    for (const string& keys : keymap) {
        for (int i = 0; i < keys.size(); ++i) {
            char c = keys[i];
            if (minPress.count(c)) 
                minPress[c] = min(minPress[c], i + 1);
            else
                minPress[c] = i + 1;
        }
    }

    for (const string& target : targets) {
        int total = 0;
        bool possible = true;

        for (char c : target) {
            if (minPress.count(c)) {
                total += minPress[c];
                continue;
            }
               
            possible = false;
            break;
        }

        answer.push_back(possible ? total : -1);
    }

    return answer;
}
