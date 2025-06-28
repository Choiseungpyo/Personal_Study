#include <vector>
#include <queue>
#include <algorithm>
#include <limits>

using namespace std;

const long long INF = numeric_limits<long long>::max();

vector<long long> dijkstra(int start, int n, const vector<vector<pair<int, int>>>& graph) {
    vector<long long> dist(n + 1, INF);
    priority_queue<pair<long long, int>, vector<pair<long long, int>>, greater<>> pq;
    dist[start] = 0;
    pq.push({ 0, start });

    while (!pq.empty()) {
        auto [cost, now] = pq.top(); pq.pop();

        if (cost > dist[now])
            continue;

        for (auto& [next, weight] : graph[now]) {
            long long nextDist = cost + weight;
            if (nextDist < dist[next]) {
                dist[next] = nextDist;
                pq.push({ nextDist, next });
            }
        }
    }
    return dist;
}

int solution(int n, int s, int a, int b, vector<vector<int>> fares) {
    vector<vector<pair<int, int>>> graph(n + 1);
    for (auto& fare : fares) {
        int u = fare[0];
        int v = fare[1];
        int w = fare[2];
        graph[u].emplace_back(v, w);
        graph[v].emplace_back(u, w);
    }

    vector<long long> distS = dijkstra(s, n, graph);
    vector<long long> distA = dijkstra(a, n, graph);
    vector<long long> distB = dijkstra(b, n, graph);

    long long answer = INF;
    for (int i = 1; i <= n; i++) {
        if (distS[i] == INF || distA[i] == INF || distB[i] == INF)
            continue;

        answer = min(answer, distS[i] + distA[i] + distB[i]);
    }

    return static_cast<int>(answer);
}