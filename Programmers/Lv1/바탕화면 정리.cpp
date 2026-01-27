#include <string>
#include <vector>

using namespace std;


void setAnswer(vector<int>& answer, int row, int col)
{
    if (row < answer[0])
        answer[0] = row;
    if (row > answer[2])
        answer[2] = row;

    if (col < answer[1])
        answer[1] = col;
    if (col > answer[3])
        answer[3] = col;
}

vector<int> solution(vector<string> wallpaper) {
    vector<int> answer = { 50,50,0,0 };

    for (int row = 0; row < wallpaper.size(); ++row)
    {
        const auto& str = wallpaper[row];
        for (int col = 0; col < str.size(); ++col)
        {
            if (str[col] == '#')
                setAnswer(answer, row, col);
        }
    }

    ++answer[2];
    ++answer[3];

    return answer;
}