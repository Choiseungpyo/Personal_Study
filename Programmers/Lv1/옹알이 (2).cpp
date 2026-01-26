#include <string>
#include <vector>
using namespace std;

int solution(vector<string> babbling) {
    vector<string> say = { "aya", "ye", "woo", "ma" };
    int answer = 0;

    for (const string& w : babbling) {
        size_t i = 0;
        int last = -1;
        bool ok = true;

        while (i < w.size()) {
            bool matched = false;

            for (int k = 0; k < say.size(); ++k) {
                const string& s = say[k];

                if (k == last)
                    continue;

                if (i + s.size() <= w.size() && w.compare(i, s.size(), s) == 0) {
                    i += s.size();
                    last = k;
                    matched = true;
                    break;
                }
            }

            if (!matched) {
                ok = false;
                break;
            }
        }

        if (ok)
            ++answer;
    }

    return answer;
}