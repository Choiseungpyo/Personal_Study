# 소수 확인
def checkIfItIsPrimeNum(n):
    cnt = 0
    
    for i in range(1, n+1):
        if num % i == 0:
            cnt += 1
            if cnt > 2:
                return False
    return cnt == 2

# Main
primeNumSum = 0
minPrimeNum = 0
m = int(input())
n = int(input())
minPrimeNum = n

for num in range(m, n+1):
    if checkIfItIsPrimeNum(num):
        primeNumSum += num
        if minPrimeNum > num:
            minPrimeNum = num


if primeNumSum != 0:
   print(primeNumSum)
else:
    minPrimeNum = -1

print(minPrimeNum)