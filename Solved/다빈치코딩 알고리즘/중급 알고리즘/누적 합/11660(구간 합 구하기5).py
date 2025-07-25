import sys
input = sys.stdin.readline

N, M = map(int, input().split())

arr = [ [0] * (N + 1) ]
for _ in range(N):
    line = [0] + list(map(int, input().split()))
    arr.append(line)

sum_arr = [[0] * (N+1) for _ in range(N+1)]

for i in range(1, N+1):
    for j in range(1, N+1):
        sum_arr[i][j] = arr[i][j] + sum_arr[i][j-1] + sum_arr[i-1][j] - sum_arr[i-1][j-1]

for _ in range(M):
    i1, j1, i2, j2 = map(int, input().split())
    ans = sum_arr[i2][j2] - sum_arr[i2][j1-1] - sum_arr[i1-1][j2] + sum_arr[i1-1][j1-1]
    print(ans)
