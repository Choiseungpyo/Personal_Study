from collections import deque

def dfs(node, graph, visited):
    visited[node] = True
    result = [node]
    
    for neighbor in graph[node]:
        if not visited[neighbor]:
            result.extend(dfs(neighbor, graph, visited))
            
    return result

def bfs(src, graph, N):
    visited = [False] * (N + 1)
    queue = deque([src])
    visited[src] = True
    result = []

    while queue:
        current = queue.popleft()
        result.append(current)
        for neighbor in graph[current]:
            if not visited[neighbor]:
                visited[neighbor] = True
                queue.append(neighbor)
                
    return result

# Main
N, M, V = map(int, input().split())
graph = [[] for _ in range(N + 1)]
for _ in range(M):
    src, dst = map(int, input().split())
    graph[src].append(dst)
    graph[dst].append(src)
for edges in graph:
    edges.sort()

visited = [False] * (N + 1)
dfs_result = dfs(V, graph, visited)
bfs_result = bfs(V, graph, N)

print(' '.join(map(str, dfs_result)))
print(' '.join(map(str, bfs_result)))