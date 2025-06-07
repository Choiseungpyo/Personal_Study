#include <string>
#include <vector>

using namespace std;

void dfs(const vector<vector<int>>& computers, vector<bool>& visited, int node, int n) {
    visited[node] = true;

    for (int i = 0; i < n; i++)
    {
        if (computers[node][i] == 1 && !visited[i])
            dfs(computers, visited, i, n);
    }
}


int solution(int n, vector<vector<int>> computers) {
    int answer = 0;
    vector<bool> visited(n, false);

    for (int i = 0; i < n; i++)
    {
        if (!visited[i])
        {
            dfs(computers, visited, i, n);
            answer++;
        }
    }

    return answer;
}