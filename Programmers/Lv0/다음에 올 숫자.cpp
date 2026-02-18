#include <vector>
using namespace std;

int solution(vector<int> c) {
    return (c[1] - c[0] == c[2] - c[1]) ? (c.back() + (c[1] - c[0])) : (c.back() * (c[1] / c[0]));
}