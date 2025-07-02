#include <iostream>
#include <vector>
#include <string>
#include <climits>
using namespace std;

int solution(vector<string> arr) {
    vector<int> nums;
    vector<char> ops;
    for (int i = 0; i < arr.size(); ++i) {
        if (i % 2 == 0)
            nums.push_back(stoi(arr[i]));
        else
            ops.push_back(arr[i][0]);
    }

    int n = nums.size();
    vector<vector<int>> dp_max(n, vector<int>(n, INT_MIN));
    vector<vector<int>> dp_min(n, vector<int>(n, INT_MAX));

    for (int i = 0; i < n; ++i)
    {
        dp_max[i][i] = nums[i];
        dp_min[i][i] = nums[i];
    }


    for (int d = 1; d < n; ++d) {
        for (int i = 0; i + d < n; ++i) {
            int j = i + d;
            for (int k = i; k < j; ++k) {
                int a = dp_max[i][k], b = dp_min[i][k];
                int c = dp_max[k + 1][j], d = dp_min[k + 1][j];

                if (ops[k] == '+') {
                    dp_max[i][j] = max(dp_max[i][j], a + c);
                    dp_min[i][j] = min(dp_min[i][j], b + d);
                }
                else {
                    dp_max[i][j] = max(dp_max[i][j], a - d);
                    dp_min[i][j] = min(dp_min[i][j], b - c);
                }
            }
        }
    }

    return dp_max[0][n - 1];
}