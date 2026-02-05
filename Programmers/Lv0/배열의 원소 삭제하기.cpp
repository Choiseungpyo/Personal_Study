#include <string>
#include <vector>
#include <unordered_set>

using namespace std;

vector<int> solution(vector<int> arr, vector<int> delete_list) {
    vector<int> answer;
    unordered_set<int> deleteSet;

    for (auto d : delete_list)   deleteSet.insert(d);

    for (auto a : arr) {
        if (deleteSet.find(a) == deleteSet.end())    answer.push_back(a);
    }

    return answer;
}