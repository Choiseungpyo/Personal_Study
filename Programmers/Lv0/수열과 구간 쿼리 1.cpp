#include <string>
#include <vector>

using namespace std;

vector<int> solution(vector<int> arr, vector<vector<int>> queries) {
    vector<int> answer;

    for (int i = 0; i < queries.size(); ++i)
    {
        auto query = queries[i];
        for (int a = query[0]; a <= query[1]; ++a)
            ++arr[a];
    }

    answer = arr;

    return answer;
}