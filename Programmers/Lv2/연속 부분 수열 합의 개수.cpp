#include <vector>
#include <unordered_set>
using namespace std;

int solution(vector<int> elements) {
    int n = elements.size();

    vector<int> ext = elements;
    ext.insert(ext.end(), elements.begin(), elements.end());

    vector<int> prefixSum(2 * n + 1, 0);
    for (int i = 0; i < 2 * n; ++i)
        prefixSum[i + 1] = prefixSum[i] + ext[i];

    unordered_set<int> set;
    set.reserve(n * n);

    for (int len = 1; len <= n; ++len) {
        for (int start = 0; start < n; ++start) {
            int sum = prefixSum[start + len] - prefixSum[start];
            set.insert(sum);
        }
    }

    return set.size();
}