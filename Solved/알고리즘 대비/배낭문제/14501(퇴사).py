import sys
sys.setrecursionlimit(10**5)

def f(day):
    if N <= day:
        return 0
    
    if memo[day] is not None:
        return memo[day]

    case1 = f(day + 1)
    case2 = 0
    
    if day + T[day] <= N:
        case2 = f(day + T[day]) + P[day]
        
    memo[day] = max(case1, case2)
    return memo[day]

# Main
N = int(input())
T = [None] * N
P = [None] * N
for i in range(N):
    T[i], P[i] = map(int, input().split())

memo = [None] * (N + 1)
print(f(0))