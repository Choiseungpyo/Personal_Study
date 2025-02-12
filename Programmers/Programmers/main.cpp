#include <vector>
#include <iostream>
#include <algorithm>

using namespace std;

vector<int> solution(vector<int> arr)
{
    vector<int> answer = { arr[0] };

    for (int i = 1; i < arr.size(); i++)
    {
        if (answer.back() != arr[i])
            answer.push_back(arr[i]);
    }

    return answer;
}
int main(void) 
{
    vector<int> arr = { 4,4,4,3,3,1 };
    auto result = solution(arr);

    return 0;
}