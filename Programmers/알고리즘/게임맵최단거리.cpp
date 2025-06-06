#include <vector>
#include <queue>
using namespace std;

int solution(vector<vector<int>> maps) {
    int maxRow = maps.size();
    int maxCol = maps[0].size();

    vector<vector<bool>> visited(maxRow, vector<bool>(maxCol, false));
    vector<vector<int>> dist(maxRow, vector<int>(maxCol, 0));
    queue<pair<int, int>> q;

    vector<pair<int, int>> directions = {
        {-1, 0},
        {1, 0},
        {0, -1},
        {0, 1}
    };

    q.push({ 0, 0 });
    visited[0][0] = true;
    dist[0][0] = 1;

    while (!q.empty()) {
        pair<int, int> cur = q.front();
        q.pop();

        int row = cur.first;
        int col = cur.second;

        if (row == maxRow - 1 && col == maxCol - 1)
            return dist[row][col];

        for (int i = 0; i < directions.size(); i++) {
            int newRow = row + directions[i].first;
            int newCol = col + directions[i].second;

            if (newRow >= 0 && newRow < maxRow && newCol >= 0 && newCol < maxCol) {
                if (!visited[newRow][newCol] && maps[newRow][newCol] == 1) {
                    visited[newRow][newCol] = true;
                    dist[newRow][newCol] = dist[row][col] + 1;
                    q.push({ newRow, newCol });
                }
            }
        }
    }

    return -1;
}