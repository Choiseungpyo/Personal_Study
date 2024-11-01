# 소수 확인
def checkIfItIsPrimeNum(n):
    cnt = 0
    
    for i in range(1, n+1):
        if num % i == 0:
            cnt += 1
            if cnt > 2:
                return False
    return True if cnt == 2 else False

cnt = int(input())
primeNumCnt = 0
storage = list(map(int, input().split()))

for num in storage:
    if checkIfItIsPrimeNum(num):
        primeNumCnt +=1
print(primeNumCnt)