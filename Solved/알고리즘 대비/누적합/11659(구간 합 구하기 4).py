import sys
input = sys.stdin.readline
N, M = map(int, input().split())
lst = list(map(int, input().split()))
sum = [0] * (N+1)
for i in range(1, N+1):
    sum[i] += sum[i-1] + lst[i-1]
    
for _ in range(M):
    i, j = map(int, input().split())
    print(sum[j] - sum[i-1])