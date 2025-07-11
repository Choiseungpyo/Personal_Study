N, K = map(int, input().split())
ball = N - (K+1) * K // 2
result = -1
if ball >= 0:
    result = K - 1
    if ball % K:
        result = K
       
print(result)