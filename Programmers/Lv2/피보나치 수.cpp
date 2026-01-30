int solution(int n) {
    const int mod = 1234567;
    int prv = 0;
    int curr = 1;

    for (int i = 2; i <= n; ++i) {
        int next = prv + curr;
        if (next >= mod) next %= mod;
        prv = curr;
        curr = next;
    }
    return curr;
}