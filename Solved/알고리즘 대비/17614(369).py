N = int(input())
cnt = 0
check = ["3", "6", "9"]
for i in range(1, N+1):
    s = str(i)
    for c in check:
        if c in s:
            cnt += s.count(c)
print(cnt)