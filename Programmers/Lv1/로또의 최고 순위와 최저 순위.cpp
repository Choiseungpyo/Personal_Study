#include <string>
#include <vector>
#include <algorithm>

using namespace std;

int getResult(int n) {

    if (n >= 6)    return 1;
    else if (n == 5)  return 2;
    else if (n == 4)  return 3;
    else if (n == 3)  return 4;
    else if (n == 2)  return 5;
    return 6;
}

vector<int> solution(vector<int> lottos, vector<int> win_nums) {
    vector<int> answer(2, 0);

    for (auto l : lottos) {
        if (l == 0)  ++answer[0];

        auto it = find(win_nums.begin(), win_nums.end(), l);
        if (it != win_nums.end())    ++answer[1];
    }

    answer[0] = getResult(answer[1] + answer[0]);
    answer[1] = getResult(answer[1]);

    return answer;
}