import sys
n = int(input())
for _ in range(n):
    data = sys.stdin.readline().rstrip()
    result = 0
    score = 0
    for i in range(len(data)):
        if data[i] == 'O':
            score += 1
            result += score
        else:
            score = 0
    print(result)