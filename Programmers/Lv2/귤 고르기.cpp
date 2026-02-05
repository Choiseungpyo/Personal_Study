#include <string>
#include <vector>
#include <algorithm>

using namespace std;

int solution(int k, vector<int> tangerine) {
    int answer = 0;
    vector<int> data(10000001, 0);
    int i = 0;

    for (auto t : tangerine)    ++data[t];

    sort(data.begin(), data.end(), [](int a, int b) {return a > b; });

    while (k > 0) {
        k -= data[i++];
        ++answer;
    }

    return answer;
}