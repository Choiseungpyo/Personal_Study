#include <string>
#include <vector>

using namespace std;

int f(vector<int> numbers, int target, int i = 0, int result = 0)
{
    if (i == numbers.size())
        return result == target ? 1 : 0;

    return f(numbers, target, i + 1, result + numbers[i])
        + f(numbers, target, i + 1, result - numbers[i]);
}

int solution(vector<int> numbers, int target) {
    int answer = f(numbers, target);
    return answer;
}