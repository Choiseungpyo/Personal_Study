#include <vector>
using namespace std;

void getPos(int x, int w, int& row, int& col) {
    int idx = x - 1;
    row = idx / w;
    int idxInRow = idx % w;
    col = (row % 2 == 0) ? idxInRow : (w - 1 - idxInRow);
}

int solution(int n, int w, int num) {
    int rowNum, colNum;
    getPos(num, w, rowNum, colNum);

    int totalRows = (n + w - 1) / w;
    int lastRow = totalRows - 1;
    int lenLast = n - lastRow * w;

    bool hasInLast = true;
    if (lenLast < w) {
        if (lastRow % 2 == 0) hasInLast = (colNum < lenLast);
        else hasInLast = (colNum >= w - lenLast);
    }

    int answer = lastRow - rowNum + 1;
    if (!hasInLast) answer -= 1;
    return answer;
}