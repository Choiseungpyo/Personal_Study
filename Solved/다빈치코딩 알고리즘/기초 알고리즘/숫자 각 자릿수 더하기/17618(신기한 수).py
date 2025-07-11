N = int(input())
cnt = 0
sum = [0] * (N + 1)

for i in range(1, N + 1):
    sum[i] = sum[i // 10] + (i % 10)
    if i % sum[i] == 0:
        cnt += 1

print(cnt)