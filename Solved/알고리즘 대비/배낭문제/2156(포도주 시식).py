import sys
sys.setrecursionlimit(10**5)

def f(n):  
    if n == 0:
        return W[0]
    elif n == 1:
        return W[0] + W[1]
    elif n == 2:
        return max(f(1), max(W[0], W[1]) + W[2])

    if memo[n] is not None:
        return memo[n]

    case1 = f(n-1)
    case2 = f(n-2) + W[n]
    case3 = f(n-3) + W[n-1] + W[n]

    memo[n] = max(case1, case2, case3)
    return memo[n]

# Main
N = int(input())
W = [int(input()) for _ in range(N)]

memo = [None] * N
print(f(N-1))