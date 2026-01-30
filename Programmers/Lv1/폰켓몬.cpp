#include <vector>
#include <algorithm>
#include <set>
using namespace std;

int solution(vector<int> nums)
{
    int size = nums.size() / 2;
    set<int> set;

    sort(nums.begin(), nums.end());
    for (auto num : nums) {
        set.insert(num);
    }

    return size < set.size() ? size : set.size();
}