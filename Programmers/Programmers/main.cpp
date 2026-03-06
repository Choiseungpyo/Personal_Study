int solution(int n) {
    int cnt = 0;
    for (int i = 1; i * i <= n; ++i)
        if (n % i == 0) cnt += (i * i == n ? 1 : 2);
    return cnt;
}

int main()
{
    auto tmp = solution(
       20
    );

    return 0;
}