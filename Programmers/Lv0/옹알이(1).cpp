#include <string>
#include <vector>
using namespace std;

int solution(vector<string> babbling) {
    const vector<string> words = { "aya", "ye", "woo", "ma" };
    int answer = 0;

    for (const string& s : babbling) {
        int i = 0;
        while (i < (int)s.size()) {
            int old = i;
            for (const string& w : words) {
                int len = w.size();
                if (i + len <= (int)s.size() && s.compare(i, len, w) == 0) {
                    i += len;
                    break;
                }
            }
            if (i == old) {
                i = -1;
                break;
            }
        }
        if (i != -1) ++answer;
    }

    return answer;
}