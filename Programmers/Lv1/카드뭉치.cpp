#include <string>
#include <vector>

using namespace std;

string solution(vector<string> cards1, vector<string> cards2, vector<string> goal) {
    int i = 0, j = 0;
    int cards1_size = cards1.size();
    int cards2_size = cards2.size();

    for (const string& word : goal) {
        if (i < cards1_size && cards1[i] == word)
            ++i;
        else if (j < cards2_size && cards2[j] == word)
            ++j;
        else
            return "No";
    }

    return "Yes";
}