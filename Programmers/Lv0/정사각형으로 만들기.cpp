#include <vector>
using namespace std;

vector<vector<int>> solution(vector<vector<int>> arr) {
    int row = arr.size();
    int col = arr[0].size();

    if (row > col) for (auto& rowVec : arr) rowVec.resize(row, 0);
    else if (col > row) arr.resize(col, vector<int>(col, 0));

    return arr;
}