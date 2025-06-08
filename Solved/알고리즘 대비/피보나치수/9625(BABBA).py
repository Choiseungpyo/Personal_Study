def f(n):
    if n == 0:
        return (1, 0)
    if n == 1:
        return (0, 1)
    
    if memo[n]:
        return memo[n]
    x1, y1 = f(n-1)
    x2, y2 = f(n-2)
    memo[n] = (x1+x2, y1+y2)
    return memo[n]

# Main
n = int(input())
memo = [None] * (n+1)
print(*f(n))