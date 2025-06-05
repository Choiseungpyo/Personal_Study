#include <string>
#include <vector>
#include <algorithm>

using namespace std;

vector<string> dfs(string dst, vector<vector<string>>& tickets, vector<bool>& visited, vector<string> answer, int ticket_size)
{
    answer.push_back(dst);

    if (answer.size() == ticket_size + 1)
        return answer;

    for (int i = 0; i < ticket_size; i++)
    {
        if (!visited[i] && tickets[i][0] == dst) {
            visited[i] = true;
            vector<string> result = dfs(tickets[i][1], tickets, visited, answer, ticket_size);
            visited[i] = false;

            if (!result.empty()) return result;
        }
    }

    return {};
}

vector<string> solution(vector<vector<string>> tickets) {
    vector<string> answer;
    int ticket_size = tickets.size();
    vector<bool> visited(ticket_size, false);
    sort(tickets.begin(), tickets.end());

    return dfs("ICN", tickets, visited, answer, ticket_size);
}