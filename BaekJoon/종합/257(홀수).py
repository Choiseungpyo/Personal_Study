import sys
sum = 0
minNum = 100
for _ in range(7):
    n = int(sys.stdin.readline())
    if n % 2 != 0:
        sum += n
        if n < minNum:
            minNum = n
print(f"{sum}\n{-1 if minNum == 100 else minNum}")