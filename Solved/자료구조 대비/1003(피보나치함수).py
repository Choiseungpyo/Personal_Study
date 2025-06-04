import sys

memo = [[-1, -1] for _ in range(41)]

def fibonacci(n):
    if n == 0:
        return [1, 0]
    elif n == 1:
        return [0, 1]
    if memo[n][0] != -1:
        return memo[n]
    
    a = fibonacci(n-1)
    b = fibonacci(n-2)
    memo[n] = [a[0] + b[0], a[1] + b[1]]
    return memo[n]

t = int(input())
for _ in range(t):
    n = int(sys.stdin.readline())
    result = fibonacci(n)
    print(result[0], result[1])