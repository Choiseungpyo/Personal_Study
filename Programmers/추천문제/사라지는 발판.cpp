#include <vector>
#include <algorithm>
#include <climits>
using namespace std;

class DisappearingGame {
private:
    vector<vector<int>> board;
    int n, m;
    int dx[4] = { 1, -1, 0, 0 };
    int dy[4] = { 0, 0, 1, -1 };

    pair<bool, int> dfs(int x, int y, int ox, int oy) {
        if (board[x][y] == 0)
            return { false, 0 };

        bool canMove = false;
        bool canWin = false;
        int minWinTurn = INT_MAX;
        int maxLoseTurn = 0;

        board[x][y] = 0;

        for (int dir = 0; dir < 4; ++dir) {
            int nx = x + dx[dir];
            int ny = y + dy[dir];

            if (nx < 0 || ny < 0 || nx >= n || ny >= m)
                continue;

            if (board[nx][ny] == 0)
                continue;

            canMove = true;
            auto [opponentWin, turn] = dfs(ox, oy, nx, ny);

            if (!opponentWin) {
                canWin = true;
                minWinTurn = min(minWinTurn, turn + 1);
            }
            else if (!canWin) {
                maxLoseTurn = max(maxLoseTurn, turn + 1);
            }
        }

        board[x][y] = 1;

        if (!canMove)
            return { false, 0 };

        if (canWin)
            return { true, minWinTurn };

        return { false, maxLoseTurn };
    }

public:
    int solve(vector<vector<int>> inputBoard, vector<int> aloc, vector<int> bloc) {
        board = inputBoard;
        n = board.size();
        m = board[0].size();
        return dfs(aloc[0], aloc[1], bloc[0], bloc[1]).second;
    }
};

int solution(vector<vector<int>> board, vector<int> aloc, vector<int> bloc) {
    DisappearingGame game;
    return game.solve(board, aloc, bloc);
}