# 입력 값이 올바른지 확인
def checkIfInputIsCorrect(n):
    if n.isdigit() == False:
        print('숫자가 아닌 값을 입력하였습니다.')
        return False
    n = int(n)
    if (n < 4 or n > 1000) or n % 4 != 0:
        print('범위가 올바르지 않습니다.')
        return False
    return True

# 정수 자료형의 이름을 출력
def printIntegerDataType(n):
    for i in range(int(n /4)):
        print('long', end = ' ')
    print('int')
    
# Main
N = input()
if checkIfInputIsCorrect(N):
    printIntegerDataType(int(N))
