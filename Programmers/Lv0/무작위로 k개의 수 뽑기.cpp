#include <string>
#include <vector>
#include <bitset>

using namespace std;

vector<int> solution(vector<int> arr, int k) {
    vector<int> answer;
    bitset<100001> bitset;

    answer.reserve(k);

    for (const auto& a : arr)
    {
        if (answer.size() > k)
            break;

        if (!bitset.test(a))
        {
            bitset.set(a);
            answer.push_back(a);
        }
    }

    answer.resize(k, -1);
    return answer;
}