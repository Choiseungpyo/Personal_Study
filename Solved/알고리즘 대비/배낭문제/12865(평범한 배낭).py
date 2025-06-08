def f(n, k):
    if n < 0:
        return 0

    if memo[n][k] is not None:
        return memo[n][k]

    case1 = 0
    prev_k = k - W[n]
    
    if 0 <= prev_k:
        case1 = f(n-1, prev_k) + V[n] 
        
    case2 = f(n-1, k)
    memo[n][k] = max(case1, case2)
    
    return memo[n][k] 

# Main
N, K = map(int, input().split())
W = [0] * N
V = [0] * N
for i in range(N):
    W[i], V[i] = map(int, input().split())
    
memo = [[None] * (K+1) for _ in range(N)]
print(f(N-1, K))