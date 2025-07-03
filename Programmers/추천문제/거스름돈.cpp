#include <vector>

const int MOD = 1000000007;

int solution(int n, std::vector<int> money) {
    std::vector<int> dp(n + 1, 0);
    dp[0] = 1;

    for (auto coin : money)
        for (auto i = coin; i <= n; ++i)
            dp[i] = (dp[i] + dp[i - coin]) % MOD;

    return dp[n];
}
