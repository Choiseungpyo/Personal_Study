import sys

# N 값이 올바른지 확인
def checkIfNIsCorrect(n):
    if n.isdigit() == False:
        print("잘못된 값을 입력하였습니다")
        return False
    
    n = int(n)
    if n < 1 or n > 1000000:
        print("값의 범위가 올바르지 않습니다")
        return False
    
    return True

# data 값이 올바른지 확인
def checkIfDataIsCorrect(data, n):
    # 입력한 값이랑 설정한 입력 개수랑 맞지 않은 경우
    if len(data) != n:
        print("입력한 숫자 개수가 맞지 않습니다.")
        return False
    
    for i in data:    
        i = int(i)
        if i < -1000000 or i > 1000000:
            print("값의 범위가 올바르지 않습니다")
            return False
    
    return True

def printMaxMinNum(n):
    data = sys.stdin.readline().strip().split()
    if checkIfDataIsCorrect(data, n) == False:
        return
    
    maxNum = -1000000
    minNum = 1000000
    for i in data:
        i = int(i)
        if i > maxNum :
            maxNum = i
        if i < minNum:
            minNum = i

    print(minNum, maxNum)   
        
n = input()
if checkIfNIsCorrect(n):
    printMaxMinNum(int(n))