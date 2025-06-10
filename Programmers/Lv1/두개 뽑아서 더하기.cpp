#include <string>
#include <vector>
#include <set>
using namespace std;

vector<int> solution(vector<int> numbers) {
    vector<int> answer;
    set<int> set;
    int n = numbers.size();

    for (int i = 0; i < n; i++)
    {
        for (int j = i + 1; j < n; j++)
            set.insert(numbers[i] + numbers[j]);
    }

    for (const auto& i : set)
        answer.push_back(i);

    return answer;
}