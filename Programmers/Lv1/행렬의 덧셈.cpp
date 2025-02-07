#include <string>
#include <vector>

using namespace std;

vector<vector<int>> solution(vector<vector<int>> arr1, vector<vector<int>> arr2) {
    vector<vector<int>> answer;

    for (int row = 0; row < arr1.size(); row++)
    {
        vector<int> tmp;
        for (int col = 0; col < arr1[row].size(); col++)
            tmp.push_back(arr1[row][col] + arr2[row][col]);
        answer.push_back(tmp);
    }

    return answer;
}