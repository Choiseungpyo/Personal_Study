from sys import stdin
from collections import deque

t = int(input())
for _ in range(t):
    n, m = map(int, stdin.readline().split())
    priority = stdin.readline().split()
    
    queue = deque((i, p) for i,p in enumerate(priority))

    order = 0
    while queue:
        curr = queue.popleft()
        if any(curr[1] < q[1] for q in queue):
            queue.append(curr)
        else:
            order += 1
            if curr[0] == m:
                print(order)
                break