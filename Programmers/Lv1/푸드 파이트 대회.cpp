#include <string>
#include <vector>
#include <deque>

using namespace std;

string solution(vector<int> food) {
    string answer = "";
    deque<int> d = { 0 };

    for (int i = food.size() - 1; i > 0; --i)
    {
        auto cnt = food[i];
        int size = cnt / 2;

        for (int a = 0; a < size; ++a)
        {
            d.push_back(i);
            d.push_front(i);
        }
    }

    for (auto i : d)
        answer += to_string(i);

    return answer;
}