#include <string>
#include <vector>

using namespace std;

vector<int> solution(int target) {
    const int INF = 100001;
    vector<pair<int, int>> dp(target + 1, { INF, 0 });
    dp[0] = { 0, 0 };

    vector<int> scores;
    for (int i = 1; i <= 20; ++i) {
        scores.push_back(i);
        scores.push_back(i * 2);
        scores.push_back(i * 3);
    }
    scores.push_back(50);

    for (int i = 1; i <= target; ++i) {
        for (int s : scores) {
            if (i < s)
                continue;

            auto [d, ss] = dp[i - s];

            if (d == INF)
                continue;

            int nd = d + 1;
            int nss = ss + ((s == 50 || (1 <= s && s <= 20)) ? 1 : 0);

            if (nd < dp[i].first)
                dp[i] = { nd, nss };
            else if (nd == dp[i].first && nss > dp[i].second)
                dp[i].second = nss;
        }
    }

    return { dp[target].first, dp[target].second };
}