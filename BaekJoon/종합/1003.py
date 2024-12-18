import sys
def fibonacci(cntData, n):
    if n == 0:
        cntData[0] += 1
        return 0
    elif n == 1:
        cntData[1] += 1
        return 1
    else:
        return fibonacci(cntData, n-1) + fibonacci(cntData, n-2)

t = int(input())
for i in range(t):
    cntData = [0,0]
    n = int(sys.stdin.readline().rstrip())
    fibonacci(cntData, n)
    print(f"{cntData[0]} {cntData[1]}")