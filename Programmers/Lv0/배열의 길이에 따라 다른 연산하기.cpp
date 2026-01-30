#include <string>
#include <vector>
#include <algorithm>

using namespace std;


vector<int> solution(vector<int> arr, int n) {
    bool isOdd = arr.size() % 2 != 0 ? true : false;
    int i = 0;

    if (isOdd)
        transform(arr.begin(), arr.end(), arr.begin(), [&i, &n](int x) {return i++ % 2 == 0 ? n + x : x; });
    else
        transform(arr.begin(), arr.end(), arr.begin(), [&i, &n](int x) {return i++ % 2 != 0 ? n + x : x; });

    return arr;
}