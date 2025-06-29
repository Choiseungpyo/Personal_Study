#include <vector>
#include <algorithm>
#include <unordered_map>
#include <set>

using namespace std;

void dfs(int current, int sheep, int wolf,
    const vector<int>& info,
    const unordered_map<int, vector<int>>& tree,
    vector<int> nextNodes,
    int& maxSheep) {

    if (info[current] == 0)
        sheep++;
    else
        wolf++;

    if (wolf >= sheep)
        return;

    maxSheep = max(maxSheep, sheep);

    // 안전하게 자식 노드 추가
    auto it = tree.find(current);
    if (it != tree.end()) {
        for (int child : it->second)
            nextNodes.push_back(child);
    }

    for (int i = 0; i < nextNodes.size(); ++i) {
        vector<int> next = nextNodes;
        int nextNode = next[i];
        next.erase(next.begin() + i);
        dfs(nextNode, sheep, wolf, info, tree, next, maxSheep);
    }
}

int solution(vector<int> info, vector<vector<int>> edges) {
    unordered_map<int, vector<int>> tree;

    for (const auto& edge : edges)
        tree[edge[0]].push_back(edge[1]);

    int maxSheep = 0;
    vector<int> nextNodes;
    dfs(0, 0, 0, info, tree, nextNodes, maxSheep);

    return maxSheep;
}