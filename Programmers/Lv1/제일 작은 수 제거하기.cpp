#include <string>
#include <vector>
#include <algorithm>

using namespace std;

vector<int> solution(vector<int> arr) {
    vector<int> answer = { -1 };

    if (!arr.empty())
    {
        vector<int>::iterator minIt = arr.begin();
        for (auto it = arr.begin() + 1; it < arr.end(); it++)
        {
            if (*it < *minIt)
                minIt = it;
        }

        arr.erase(minIt);
        answer.assign(arr.begin(), arr.end());

        if (answer.empty())
            answer.push_back(-1);
    }
    return answer;
}