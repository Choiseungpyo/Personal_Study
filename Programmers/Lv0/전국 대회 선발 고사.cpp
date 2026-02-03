#include <string>
#include <vector>
#include <algorithm>

using namespace std;

int solution(vector<int> rank, vector<bool> attendance) {
    int size = rank.size();
    vector<int> participants;
    participants.reserve(size);

    for (int i = 0; i < size; ++i) {
        if (attendance[i])  participants.push_back(i);
    }

    sort(participants.begin(), participants.end(), [&rank](int a, int b) {
        return rank[a] < rank[b];
        });

    return 10000 * participants[0] + 100 * participants[1] + participants[2];
}