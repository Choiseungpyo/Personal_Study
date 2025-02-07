from sys import stdin

def round(n):
    if n - int(n) >= 0.5:
        return int(n) + 1
    return int(n)

n = int(stdin.readline())
if n != 0:
    trimmedMean = 30
    data = [0] * n
    for i in range(n):
        data[i] = int(stdin.readline())
    data.sort()

    num = round(n*trimmedMean/2/100)
    data = data[num:n-num]
    print(round(sum(data) / len(data)))   
else:
    print(n)