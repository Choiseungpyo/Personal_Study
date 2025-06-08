def f(n):
    if n <= 2:
        return n
    if memo[n] >= 0:
        return memo[n]
    memo[n] = (f(n-1) + f(n-2)) % 10007
    return memo[n]

# Main
n = int(input())
memo = [-1] * (n+1)
print(f(n))