#include <string>
#include <vector>

using namespace std;

int solution(vector<int> ingredient) {
    int answer = 0;
    int k = 1;

    for (int i = 0; i < ingredient.size(); i++)
    {
        if (ingredient[i] != k)
            continue;

        if (++k == 4)
        {
            answer++;
            k = 1;
            i = 0;
        }
    }
    return answer;
}
int main()
{
    vector<int> tmp = { 1, 3, 2, 1, 2, 1, 3, 1, 2 };
    auto a  = solution(tmp);
    return 0;
}