import sys 
input = sys.stdin.readline 

mii = lambda : map(int, input().split())
C = int(input())
for _ in range(C):
    d, n = mii()
    arr = list(mii())

    mod = [0] * d
    mod[0] = 1
    ans = 0
    total = 0

    for a in arr:
        total = (total + a) % d
        ans += mod[total]
        mod[total] += 1

    print(ans)