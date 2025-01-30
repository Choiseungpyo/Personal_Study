from sys import stdin
n = int(stdin.readline())
maxNum = 10000
data = [0] * maxNum
for i in range(n):
    data[int(stdin.readline())-1] += 1 
for num in range(maxNum):
    if data[num] == 0:
        continue
    for i in range(data[num]):
        print(num+1)