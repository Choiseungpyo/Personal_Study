import heapq
import sys

input = sys.stdin.readline
N = int(input())
M = int(input())
graph = [[] for _ in range(N+1)]
for i in range(M):
    a,b,c = map(int,  input().split())
    graph[a].append((c, b))
    graph[b].append((c, a))

answer = 0
cnt = 0
visited = [False] * (N+1) 
q = [(0,1)]
while q:
    w, v = heapq.heappop(q)
    
    if visited[v]:
        continue 
    
    visited[v] = True
    answer += w
    cnt += 1
    
    if cnt == N:
        break
    
    for w, u in graph[v]:
        if not visited[u]:
            heapq.heappush(q, (w, u))
           
print(answer)   