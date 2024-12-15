import sys
n = int(input())
data = []
for _ in range(n):
    num = int(sys.stdin.readline())
    if num in data:
        continue
    data.append(num )
data.sort()
for item in data:
    print(item)