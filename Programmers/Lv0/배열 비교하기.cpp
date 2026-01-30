#include <string>
#include <vector>
#include <numeric>

using namespace std;

int solution(vector<int> arr1, vector<int> arr2) {
    int arr1Size = arr1.size();
    int arr2Size = arr2.size();
    if (arr1Size > arr2Size)
        return 1;
    else if (arr1Size < arr2Size)
        return -1;

    int sum1 = accumulate(arr1.begin(), arr1.end(), 0);
    int sum2 = accumulate(arr2.begin(), arr2.end(), 0);

    if (sum1 > sum2)
        return 1;
    else if (sum1 < sum2)
        return -1;
    return 0;
}