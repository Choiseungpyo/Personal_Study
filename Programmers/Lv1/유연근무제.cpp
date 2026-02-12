#include <vector>

using namespace std;

int toMin(int t) {
    return (t / 100) * 60 + (t % 100);
}

int solution(vector<int> schedules, vector<vector<int>> timelogs, int startday) {
    int answer = 0;
    bool work[7];

    for (int d = 0; d < 7; ++d) {
        int weekday = ((startday - 1 + d) % 7) + 1;
        work[d] = (weekday <= 5);
    }

    for (int i = 0; i < (int)schedules.size(); ++i) {
        int limit = toMin(schedules[i]) + 10;
        bool ok = true;
        for (int d = 0; d < 7; ++d) {
            if (work[d] && toMin(timelogs[i][d]) > limit) {
                ok = false;
                break;
            }
        }

        if (ok) ++answer;
    }
    return answer;
}