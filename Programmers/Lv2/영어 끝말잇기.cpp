#include <string>
#include <vector>
#include <unordered_set>

using namespace std;

vector<int> solution(int n, vector<string> words) {
    unordered_set<string> used;

    for (int i = 0; i < (int)words.size(); ++i) {
        if (words[i].size() < 2) return { i % n + 1, i / n + 1 };
        if (i > 0 && words[i - 1].back() != words[i].front()) return { i % n + 1, i / n + 1 };
        if (!used.insert(words[i]).second) return { i % n + 1, i / n + 1 };
    }
    return { 0, 0 };
}