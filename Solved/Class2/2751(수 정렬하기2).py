import sys
n = int(input())
lst = []

for _ in range(n):
    num = int(sys.stdin.readline())
    lst.append(num)
    
lst.sort()
for num in lst:
    print(num)