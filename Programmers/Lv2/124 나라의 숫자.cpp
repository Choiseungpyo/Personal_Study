#include <string>
using namespace std;

string solution(int n) {
    string answer = "";
    int nums[3] = { 4, 1, 2 }; 

    while (n > 0) {
        int r = n % 3;
        answer = to_string(nums[r]) + answer;
        n = (r == 0) ? (n - 1) / 3 : n / 3; 
    }

    return answer;
}