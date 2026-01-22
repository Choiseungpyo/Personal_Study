#include <string>
#include <vector>
#include <unordered_map>

using namespace std;

int toDays(const string& ymd) {
    int y = stoi(ymd.substr(0, 4));
    int m = stoi(ymd.substr(5, 2));
    int d = stoi(ymd.substr(8, 2));
    return y * 12 * 28 + m * 28 + d;
}

vector<int> solution(string today, vector<string> terms, vector<string> privacies) {
    vector<int> answer;

    unordered_map<int, int> termsMap;
    for (const string& t : terms) {
        char type = t[0];
        int months = stoi(t.substr(2));

        termsMap[type] = months;
    }

    int todayDays = toDays(today);

    for (int i = 0; i < (int)privacies.size(); ++i) {
        const string& p = privacies[i];

        auto dateStr = p.substr(0, 10);
        auto type = p[p.size() - 1];

        auto collectedDays = toDays(dateStr);
        auto expireStartDays = collectedDays + termsMap[type] * 28;

        if (todayDays >= expireStartDays)
            answer.push_back(i + 1);
    }

    return answer;
}