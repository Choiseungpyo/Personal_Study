import sys
m, n = map(int, sys.stdin.readline().split())
for num in range(m,n+1):
    flag = True
    for i in range(2,num):
        if num % i == 0:
            flag = False
            break
    if flag:
        print(num)