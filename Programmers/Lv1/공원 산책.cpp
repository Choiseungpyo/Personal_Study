#include <string>
#include <vector>
#include <unordered_map>

using namespace std;

void move(pair<int, int> hw, const vector<string>& park,
    pair<int, int>& pos, const pair<int, int>& dir, int dist)
{
    int row = pos.first + dir.first * dist;
    int col = pos.second + dir.second * dist;

    if (row < 0 || row >= hw.first) return;
    if (col < 0 || col >= hw.second) return;


    int r = pos.first;
    int c = pos.second;

    for (int i = 0; i < dist; ++i) {
        r += dir.first;
        c += dir.second;
        if (park[r][c] == 'X') return;
    }

    pos.first = row;
    pos.second = col;
}

pair<int, int> getStartPos(const pair<int, int>& hw, const vector<string>& park)
{
    for (int row = 0; row < hw.first; ++row)
    {
        for (int col = 0; col < hw.second; ++col)
        {
            if (park[row][col] == 'S')
                return make_pair(row, col);
        }
    }

    return make_pair(-1, -1);
}


vector<int> solution(vector<string> park, vector<string> routes) {
    unordered_map<char, pair<int, int>> dirMap = {
        {'N', {-1, 0}},
        {'S', {1, 0}},
        {'W', {0, -1}},
        {'E', {0, 1}}
    };
    pair<int, int> hw = make_pair(park.size(), park[0].size());
    pair<int, int> startPos = getStartPos(hw, park);

    for (const auto& route : routes)
    {
        const auto& dirChar = route[0];
        int dist = route[2] - '0';

        auto dir = dirMap[dirChar];

        move(hw, park, startPos, dir, dist);
    }

    return { startPos.first, startPos.second };
}