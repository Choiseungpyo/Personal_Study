from sys import stdin

n = int(stdin.readline())
lst = []

for _ in range(n):
    x, y = map(int, stdin.readline().split())
    lst.append((x,y))
lst.sort(key=lambda x : (x[1], x[0]))

for x,y in lst:
    print(f"{x} {y}")