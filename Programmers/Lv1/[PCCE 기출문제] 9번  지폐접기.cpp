#include <string>
#include <vector>

using namespace std;

int solution(vector<int> wallet, vector<int> bill) {
    int answer = 0;

    while (min(bill[0], bill[1]) > min(wallet[0], wallet[1])
        || max(bill[0], bill[1]) > max(wallet[0], wallet[1]))
    {
        int index = bill[0] <= bill[1];
        bill[index] /= 2;
        ++answer;
    }

    return answer;
}