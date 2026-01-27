#include <vector>
#include <string>
#include <unordered_map>
using namespace std;

vector<string> solution(vector<string> players, vector<string> callings) {
    unordered_map<string, int> pos;
    pos.reserve(players.size());

    for (int i = 0; i < players.size(); ++i)
        pos[players[i]] = i;


    for (const string& calling : callings) {
        int i = pos[calling];
        int j = i - 1;

        string& a = players[j];
        string& b = players[i];

        swap(a, b);

        pos[a] = j;
        pos[b] = i;
    }

    return players;
}