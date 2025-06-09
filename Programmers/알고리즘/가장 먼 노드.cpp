#include <vector>
#include <queue>

using namespace std;

int solution(int n, vector<vector<int>> edge) {
    int answer = 0;
    vector<vector<int>> graph(n);
    vector<int> distance(n, -1);
    queue<int> q;
    int max_dist = -1;

    for (const auto& e : edge)
    {
        int a = e[0] - 1;
        int b = e[1] - 1;
        graph[a].push_back(b);
        graph[b].push_back(a);
    }

    q.push(0);
    distance[0] = 0;

    while (!q.empty()) {
        int node = q.front();
        q.pop();

        for (int neighbor : graph[node])
        {
            if (distance[neighbor] != -1)
                continue;

            distance[neighbor] = distance[node] + 1;
            q.push(neighbor);
        }
    }

    for (int d : distance)
    {
        if (d > max_dist)
        {
            max_dist = d;
            answer = 1;
        }
        else if (d == max_dist)
            answer++;
    }

    return answer;
}