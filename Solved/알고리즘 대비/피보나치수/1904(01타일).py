T = int(input())

memo = [None] * (100+1)
memo[0] = 0
memo[1] = 1
memo[2] = 1

for _ in range(T):
    N = int(input())
    
    for i in range(3, N+1):
        memo[i] = memo[i-3] + memo[i-2]
        
    print(memo[N])