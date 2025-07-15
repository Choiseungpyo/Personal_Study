N = int(input())
arr = list(map(int, input().split()))

cnt_left = [0, 0]
cnt = [0, 0]

for a in arr:
    idx = a % 2
    cnt[idx] += 1
    cnt_left[idx] += cnt[1 - idx]

print(min(cnt_left))