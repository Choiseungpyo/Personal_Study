#include <string>
#include <vector>
#include <cmath>
using namespace std;

pair<int, int> getPos(int num) {
    if (num == 1) return { 0, 0 };
    if (num == 2) return { 0, 1 };
    if (num == 3) return { 0, 2 };

    if (num == 4) return { 1, 0 };
    if (num == 5) return { 1, 1 };
    if (num == 6) return { 1, 2 };

    if (num == 7) return { 2, 0 };
    if (num == 8) return { 2, 1 };
    if (num == 9) return { 2, 2 };

    return { 3, 1 };
}

int getDist(pair<int, int> a, pair<int, int> b) {
    return abs(a.first - b.first) + abs(a.second - b.second);
}

string solution(vector<int> numbers, string hand) {
    string answer = "";

    pair<int, int> leftPos = { 3, 0 };
    pair<int, int> rightPos = { 3, 2 };

    for (int num : numbers) {
        if (num == 1 || num == 4 || num == 7) {
            answer += 'L';
            leftPos = getPos(num);
        }
        else if (num == 3 || num == 6 || num == 9) {
            answer += 'R';
            rightPos = getPos(num);
        }
        else {
            pair<int, int> target = getPos(num);

            int leftDist = getDist(leftPos, target);
            int rightDist = getDist(rightPos, target);

            if (leftDist < rightDist) {
                answer += 'L';
                leftPos = target;
            }
            else if (rightDist < leftDist) {
                answer += 'R';
                rightPos = target;
            }
            else {
                if (hand == "left") {
                    answer += 'L';
                    leftPos = target;
                }
                else {
                    answer += 'R';
                    rightPos = target;
                }
            }
        }
    }

    return answer;
}