N, K = map(int, input().split())
MAX = float("INF")

coins = [None] * N
for i in range(N):
    coins[i] = int(input())

memo = [[MAX] * (K+1) for _ in range(N)]

for n in range(N):
    memo[n][0] = 0
    for k in range(1, K+1):
        case1 = MAX
        prev_k = k - coins[n]
        if prev_k >= 0:
            case1 = memo[n][prev_k] + 1
        case2 = memo[n-1][k]
        memo[n][k] = min(case1, case2)

result = -1 if memo[N-1][K] == MAX else memo[N-1][K]
print(result)