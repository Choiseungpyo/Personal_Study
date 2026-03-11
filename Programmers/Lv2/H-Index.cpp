#include <string>
#include <vector>

using namespace std;

int solution(vector<int> citations) {
    for (int i = citations.size(); i > 0; --i) {
        int min = 0;
        int max = 0;
        for (int c : citations) {
            if (c < i) ++min;
            else ++max;
        }

        if (min <= i && max >= i)    return i;
    }
    return 0;
}