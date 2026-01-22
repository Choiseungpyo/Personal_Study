#include <vector>
#include <algorithm>
#include <cstdlib>

using namespace std;

int solution(int a, int b, int c, int d) {
    int cnt[7] = { 0 };
    int v[4] = { a,b,c,d };

    for (int i = 0; i < 4; i++)
        cnt[v[i]]++;

    vector<int> keys;
    for (int x = 1; x <= 6; x++) {
        if (cnt[x])
            keys.push_back(x);
    }

    int distinct = keys.size();

    if (distinct == 1) {
        int p = keys[0];
        return 1111 * p;
    }
    if (distinct == 2) {
        int p = keys[0], q = keys[1];
        int cp = cnt[p], cq = cnt[q];
        if (cp == 3 || cq == 3) {
            int three = (cp == 3) ? p : q;
            int one = (cp == 3) ? q : p;
            int t = 10 * three + one;
            return t * t;
        }
        return (p + q) * abs(p - q);
    }
    if (distinct == 3) {
        int q = 0, r = 0;
        for (int x : keys) {
            if (cnt[x] == 1) {
                if (q == 0)
                    q = x;
                else
                    r = x;
            }
        }
        return q * r;
    }

    return *min_element(v, v + 4);
}