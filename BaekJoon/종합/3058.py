import sys
n = int(input())
for _ in range(n):
    minNum = 100
    sum = 0
    nums = map(int, sys.stdin.readline().split())
    for num in nums:
        if num % 2 == 0:
            sum += num
            if num < minNum:
                minNum = num
    print(f"{sum} {minNum}")