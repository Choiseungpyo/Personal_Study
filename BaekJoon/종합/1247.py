import sys
for _ in range(3):
    n = int(sys.stdin.readline())
    s = 0
    for _ in range(n):
        s += int(sys.stdin.readline())
    result = '0'
    if s > 0:
        result = '+'
    elif s < 0:
        result = '-'
    print(result)