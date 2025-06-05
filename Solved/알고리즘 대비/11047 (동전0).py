N, K = map(int, input().split())
A = [int(input()) for _ in range(N)]

answer = 0
for coin in A[::-1]:
    if K == 0:
        break
    answer += K // coin 
    K %= coin
print(answer)