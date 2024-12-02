import sys
scores = [100, 100]
n = int(input())
for i in range(n):
    num1, num2 = map(int, sys.stdin.readline().split())
    if num1 > num2:
        scores[1] -= num1
    elif num1 < num2:
        scores[0] -= num2
print(f"{scores[0]}\n{scores[1]}")