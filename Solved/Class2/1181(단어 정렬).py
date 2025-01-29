from sys import stdin

n = int(stdin.readline())
data = []
for _ in range(n):
    data.append(stdin.readline().rstrip())

data = list(set(data))
data.sort()
data.sort(key=lambda x :len(x))
print("\n".join(data))