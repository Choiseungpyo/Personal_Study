from sys import stdin

stdin.readline()
scores = list(map(int, stdin.readline().split()))
scores.sort()
sum = 0
for score in scores:
    sum += score/scores[-1]*100
print(sum/len(scores))