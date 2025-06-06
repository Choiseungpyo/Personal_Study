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
        {-1, 0}, // 위
        {1, 0},  // 아래
        {0, -1}, // 왼쪽
        {0, 1}   // 오른쪽
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
            int currRow = row + directions[i].first;
            int currCol = col + directions[i].second;

            if (currRow >= 0 && currRow < maxRow && currCol >= 0 && currCol < maxCol) {
                if (!visited[currRow][currCol] && maps[currRow][currCol] == 1) {
                    visited[currRow][currCol] = true;
                    dist[currRow][currCol] = dist[row][col] + 1;
                    q.push({ currRow, currCol });
                }
            }
        }
    }

    return -1;
}
int main() {
    return 0;
}