import sys
result = 1
for _ in range(3):
    result *= int(sys.stdin.readline())
s = str(result)
for i in range(0, 10):
    print(s.count(str(i)))