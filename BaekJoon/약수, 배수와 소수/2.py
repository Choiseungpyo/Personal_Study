storage = list(map(int,input().split(' ')))
divisorCnt = 0
resultDivisor = 0
for i in range(1, storage[0]+1):
    if storage[0] % i == 0:
        divisorCnt += 1
        if divisorCnt == storage[1]:
            resultDivisor = i
            break

if divisorCnt < storage[1]:
    resultDivisor = 0
print(resultDivisor)