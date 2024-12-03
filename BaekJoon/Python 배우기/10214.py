import sys
n = int(input())
for _ in range(n):
    scores = [0,0]
    for i in range(9):
        y,k = map(int, sys.stdin.readline().split())
        scores[0] += y
        scores[1] += k
    
    result = "Draw"
    if scores[0] > scores[1]:
        result = "Yonsei"
    elif scores[0] < scores[1]:
        result = "Korea"
    print(result)