#include <string>
#include <vector>
#include <algorithm>
#include <math.h>

using namespace std;

long long solution(long long n) {
    long long answer = 0;
    vector<long long> nums;

    for (int i = 0; n != 0; n /= 10)
        nums.push_back(n % 10);

    sort(nums.begin(), nums.end());

    for (int i = 0; i < nums.size(); i++)
        answer += nums[i] * pow(10, i);

    return answer;
}