import sys
m, n = map(int, sys.stdin.readline().split())
for num in range(m, n+1):
    flag = True
    if num == 1:
        continue
    for i in range(2, int(num**0.5)+1):
        if num % i == 0:
            flag = False
            break
    if flag:
        print(num)