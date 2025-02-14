from sys import stdin
n = 3
data = [0] * n
for i in range(n):
    data[i] = stdin.readline().rstrip()

print(int(data[0]) + int(data[1]) - int(data[2]))
print(int(data[0] + data[1])- int(data[2]))