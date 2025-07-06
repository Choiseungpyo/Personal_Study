#include <string>
#include <vector>
#include <climits>
using namespace std;

int solution(vector<vector<int>> matrix_sizes) {
    int n = matrix_sizes.size();
    vector<vector<long long>> dp(n, vector<long long>(n, 0));

    for (int len = 2; len <= n; ++len) {
        for (int i = 0; i + len - 1 < n; ++i) {
            int j = i + len - 1;
            dp[i][j] = LLONG_MAX;
            for (int k = i; k < j; ++k) {
                long long cost = dp[i][k] + dp[k + 1][j]
                    + 1LL * matrix_sizes[i][0] * matrix_sizes[k][1] * matrix_sizes[j][1];
                if (cost < dp[i][j])
                    dp[i][j] = cost;
            }
        }
    }

    return (int)dp[0][n - 1];
}