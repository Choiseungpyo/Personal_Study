import sys
input = sys.stdin.readline
from collections import defaultdict

N, d, k, c = map(int, input().split())
sushi = [int(input()) for _ in range(N)]
count = [0] * (d + 1)
unique = 0
max_unique = 0

for i in range(k):
    if count[sushi[i]] == 0:
        unique += 1
    count[sushi[i]] += 1

if count[c] == 0:
    max_unique = unique + 1
else:
    max_unique = unique

for i in range(1, N):
    remove = sushi[(i - 1) % N]
    count[remove] -= 1
    if count[remove] == 0:
        unique -= 1

    add = sushi[(i + k - 1) % N]
    if count[add] == 0:
        unique += 1
    count[add] += 1

    if count[c] == 0:
        max_unique = max(max_unique, unique + 1)
    else:
        max_unique = max(max_unique, unique)

print(max_unique)