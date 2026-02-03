#include <string>
#include <vector>
#include <algorithm>

using namespace std;

vector<int> solution(vector<int> num_list) {
    int size = num_list.size() - 5;
    vector<int> answer(size);

    sort(num_list.begin(), num_list.end());
    copy(num_list.cbegin() + 5, num_list.cend(), answer.begin());

    return answer;
}