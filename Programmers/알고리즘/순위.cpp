#include <string>
#include <vector>

using namespace std;

int solution(int n, vector<vector<int>> results) {
    int answer = 0;
    vector<vector<bool>> graph(n, vector<bool>(n, false));

    for (auto& result : results)
    {
        int winner = result[0] - 1;
        int loser = result[1] - 1;
        graph[winner][loser] = true;
    }

    for (int mid = 0; mid < n; mid++)
    {
        for (int start = 0; start < n; start++)
        {
            for (int end = 0; end < n; end++)
            {
                if (graph[start][mid] && graph[mid][end])
                    graph[start][end] = true;
            }
        }
    }

    for (int player = 0; player < n; player++)
    {
        int count = 0;

        for (int other = 0; other < n; other++)
        {
            if (player == other)
                continue;

            if (graph[player][other] || graph[other][player])
                count++;
        }

        if (count == n - 1)
            answer++;
    }

    return answer;
}