import sys

nums = []
sum = 0
n = int(sys.stdin.readline())
for i in range(n):
    num = int(sys.stdin.readline())
    if num == 0:
        sum -= nums.pop()
    else:
        sum += num
        nums.append(num)
print(sum)