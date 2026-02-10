long long solution(int n) {
    const int MOD = 1234567;

    int a = 1;
    int b = 1;

    for (int i = 2; i <= n; ++i) {
        int c = (a + b) % MOD;
        a = b;
        b = c;
    }
    return b;
}