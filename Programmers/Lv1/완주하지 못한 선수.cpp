#include <string>
#include <vector>
#include <algorithm>
#include <unordered_map>

using namespace std;

string solution(vector<string> participant, vector<string> completion) {
    unordered_map<string, int> participantMap;
    participantMap.reserve(participant.size());

    for (const auto& p : participant)
        participantMap[p]++;

    for (const auto& c : completion)
    {
        auto it = participantMap.find(c);
        if (it == participantMap.end())
            return c;

        if (--it->second == 0)
            participantMap.erase(it);
    }

    return participantMap.begin()->first;
}