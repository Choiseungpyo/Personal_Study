def dfs(adja, visited, node, n):
    visited[node] = True
    for i in range(n):
        if not visited[i] and adja[node][i]:
            dfs(adja, visited, i, n)

# Main
n = int(input())  
m = int(input())  

adja = [[False] * n for _ in range(n)]
for _ in range(m):
    a, b = map(int, input().split())
    adja[a - 1][b - 1] = True
    adja[b - 1][a - 1] = True 

visited = [False] * n
dfs(adja, visited, 0, n)  

print(sum(visited) - 1)