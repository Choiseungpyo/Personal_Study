import sys
n = int(input())
for i in range(n):
    a,b = map(int, sys.stdin.readline().split())
    for i in range(min(a,b), 0, -1):
        if a % i == 0 and b % i ==0:
            print(a*b//i)
            break