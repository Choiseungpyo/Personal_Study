import sys
n, m = map(int, input().split())
s = set()
cnt = 0

for _ in range(n):
    s.add(sys.stdin.readline().rstrip())
for _ in range(m):
    if sys.stdin.readline().rstrip() in s:
        cnt+=1
print(cnt)