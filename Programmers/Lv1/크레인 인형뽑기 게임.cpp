#include <string>
#include <vector>

using namespace std;

int solution(vector<vector<int>> board, vector<int> moves) {
    int answer = 0;
    vector<int> basket;

    for (auto m : moves) {
        for (int i = 0; i < board.size(); ++i) {
            auto& target = board[i][m - 1];
            if (target) {
                auto tmp = board[i][m - 1];
                target = 0;
                if (!basket.empty() && basket.back() == tmp) {
                    basket.pop_back();
                    answer += 2;
                }
                else {
                    basket.push_back(tmp);
                }

                break;
            }
        }
    }

    return answer;
}