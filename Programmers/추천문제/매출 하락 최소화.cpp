#include <bits/stdc++.h>
using namespace std;

void dfs(int cur,
    const vector<vector<int>>& team,
    const vector<int>& salesInfo,
    vector<vector<int>>& dp)
{
    dp[cur][0] = 0;
    dp[cur][1] = salesInfo[cur - 1];

    if (team[cur].empty()) 
        return;

    int minValue = INT_MAX;

    for (int next : team[cur]) {
        dfs(next, team, salesInfo, dp);

        if (dp[next][0] < dp[next][1]) {
            dp[cur][0] += dp[next][0];
            dp[cur][1] += dp[next][0];
            minValue = min(minValue, dp[next][1] - dp[next][0]);
        }
        else {
            dp[cur][0] += dp[next][1];
            dp[cur][1] += dp[next][1];
            minValue = 0;
        }
    }

    dp[cur][0] += minValue;
}

int solution(vector<int> sales, vector<vector<int>> links) {
    int n = sales.size();
    vector<vector<int>> team(n + 1);
    vector<vector<int>> dp(n + 1, vector<int>(2, 0));

    for (const auto& link : links)
        team[link[0]].push_back(link[1]);

    dfs(1, team, sales, dp);
    return min(dp[1][0], dp[1][1]);
}