#include <vector>
using namespace std;

vector<int> solution(vector<int> arr, vector<int> query) {
    for (int i = 0; i < (int)query.size(); ++i) {
        int q = query[i];

        if (i % 2 == 0)
            arr.erase(arr.begin() + q + 1, arr.end());
        else
            arr.erase(arr.begin(), arr.begin() + q);
    }
    return arr;
}