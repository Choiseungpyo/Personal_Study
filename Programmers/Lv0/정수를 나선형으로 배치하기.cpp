#include <vector>
using namespace std;

struct Dir { int y; int x; };

vector<vector<int>> solution(int n) {
    vector<vector<int>> answer(n, vector<int>(n, 0));
    Dir dirs[4] = { {0, 1}, {1, 0}, {0, -1}, {-1, 0} };
    Dir pos{ 0, 0 };

    int dirIndex = 0;
    int num = 1;

    while (num <= n * n) {
        answer[pos.y][pos.x] = num++;

        Dir nextPos{ pos.y + dirs[dirIndex].y, pos.x + dirs[dirIndex].x };

        if (nextPos.x < 0 || nextPos.x >= n || nextPos.y < 0 || nextPos.y >= n ||
            answer[nextPos.y][nextPos.x] != 0) {
            dirIndex = (dirIndex + 1) % 4;
            nextPos = { pos.y + dirs[dirIndex].y, pos.x + dirs[dirIndex].x };
        }

        pos = nextPos;
    }

    return answer;
}