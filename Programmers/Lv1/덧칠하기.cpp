#include <string>
#include <vector>
#include <algorithm>

using namespace std;

int solution(int n, int m, vector<int> section) {
    int answer = 0;
    int i = 0;
    int size = section.size();

    while (i < size)
    {
        auto start = section[i];
        auto end = start + m - 1;

        while (i < size && section[i] <= end)
            ++i;

        ++answer;
    }

    return answer;
}