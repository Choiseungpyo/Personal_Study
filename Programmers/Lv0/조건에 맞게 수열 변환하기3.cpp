#include <vector>
#include <algorithm>
using namespace std;

vector<int> solution(vector<int> arr, int k) {
    vector<int> answer;
    answer.resize(arr.size());

    transform(arr.begin(), arr.end(), answer.begin(),
        [k](int x) {
            return (k % 2 == 0) ? x + k : x * k;
        });

    return answer;
}