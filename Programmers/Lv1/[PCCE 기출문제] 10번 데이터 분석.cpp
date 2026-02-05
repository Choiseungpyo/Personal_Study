#include <string>
#include <vector>
#include <algorithm>
#include <iterator>

using namespace std;

int toIndex(const string& s)
{
    if (s == "code") return 0;
    if (s == "date") return 1;
    if (s == "maximum") return 2;
    if (s == "remain") return 3;
    return -1;
}

vector<vector<int>> solution(vector<vector<int>> data, string ext, int val_ext, string sort_by) {
    vector<vector<int>> answer;

    int extIndex = toIndex(ext);
    int sortIndex = toIndex(sort_by);

    if (extIndex < 0 || sortIndex < 0) return answer;

    answer.reserve(data.size());

    copy_if(data.begin(), data.end(), back_inserter(answer),
        [extIndex, val_ext](const vector<int>& x) {
            return x[extIndex] < val_ext;
        }
    );

    sort(answer.begin(), answer.end(),
        [sortIndex](const vector<int>& a, const vector<int>& b) {
            return a[sortIndex] < b[sortIndex];
        }
    );

    return answer;
}