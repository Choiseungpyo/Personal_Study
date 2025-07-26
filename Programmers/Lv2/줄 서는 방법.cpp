#include <string>
#include <vector>

using namespace std;

vector<int> solution(int n, long long k) {
    vector<int> answer;
    vector<int> people;
    vector<long long> factorial(n, 1);

    for (int i = 1; i < n; ++i)
        factorial[i] = factorial[i - 1] * i;

    for (int i = 1; i <= n; ++i)
        people.push_back(i);

    --k;

    for (int i = n; i >= 1; --i) {
        int idx = k / factorial[i - 1];
        k %= factorial[i - 1];
        answer.push_back(people[idx]);
        people.erase(people.begin() + idx);
    }

    return answer;
}