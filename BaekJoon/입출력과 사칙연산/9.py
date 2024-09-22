def getSigleDigit(n , i): #값, 원하는 자리 수 
    storage = []
    controlWhile = True
    while(controlWhile):
        storage.append(int(n % 10))
        n /= 10
        if n < 10:
            storage.append(int(n % 10))
            controlWhile = False

    return storage[i]

def printResult(a, b, n): # n : 자리수 
    result = 0
    auxiliaryNum = 10
    
    for i in range(n):
        result = a * getSigleDigit(b, i)
        print(result)
        auxiliaryNum = 10 ** (i+1)
    print(a*b)

def getNums(storage, n): # n : 숫자 자리수
    for i in range(2):
        tmp = input()

        if tmp.isdigit() == False:
            print('잘못된 값을 입력하였습니다.')
            break
        if len(tmp) != n:
            print('잘못된 값을 입력하였습니다.')
            break
    
        storage[i] = int(tmp)


storage = [-1, -1]
digitNum = 3 # 숫자 자리수
getNums(storage, digitNum)

if storage[0] != -1 and storage[1] != -1:
    printResult(storage[0], storage[1], digitNum)