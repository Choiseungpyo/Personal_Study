from sys import stdin
n = int(stdin.readline())
data = []
for _ in range(n):
    x,y = map(int, stdin.readline().split())
    data.append([x,y])
data.sort()
for x,y in data:
    print(x,y)