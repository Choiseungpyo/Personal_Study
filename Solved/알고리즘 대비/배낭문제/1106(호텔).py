import sys
sys.setrecursionlimit(10**5)
def solve(n, c):
    if n < 0:
        return float('inf')

    if c <= 0:
        return 0

    if dp[n][c]:
        return dp[n][c]

    case1 = solve(n - 1, c)
    case2 = solve(n, c - customer[n]) + cost[n]
    dp[n][c] = min(case1, case2)
    return dp[n][c]

# Main
C, N = map(int, input().split())
cost = [None] * N
customer = [None] * N
for i in range(N):
    a, b = map(int, input().split())
    cost[i] = a
    customer[i] = b

dp = [[0] * (C + 1) for _ in range(N)]
print(solve(N - 1, C))