import sys

# 입력 값이 올바른지 확인
def checkIfInputIsCorrect(n, maxNum):
    if n.isdigit() == False:
        print('숫자가 아닌 값을 입력하였습니다.')
        return False
    
    n = int(n)
    if n < 1 or n > maxNum:
        print('값의 범위가 올바르지 않습니다.')
        return False

    return True

# 합산한 값을 출력
def printSum(n):
    for row in range(n):
        data = sys.stdin.readline().strip().split()
        for col in range(len(data)):
            if checkIfInputIsCorrect(data[col], 1000) == False:
                return
            data[col] = int(data[col])
        sum = data[0] + data[1]
        print(sum)

# # Main
T = input()

if checkIfInputIsCorrect(T, 1000000):
    printSum(int(T))