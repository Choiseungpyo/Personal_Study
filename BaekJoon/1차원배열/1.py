import sys

# n 입력 값 확인
def checkIfNIsCorrect(n):
    if n.isdigit() == False:
        print("올바르지 않은 값을 입력하였습니다.")
        return False
    n = int(n)
    if n < 1 or n > 100:
        print("값의 범위가 올바르지 않습니다.")
        return False
    
    return True

# v 입력 값 확인
def checkIfDataIsCorrect(data,n):
    if len(data) < 1 or len(data) > 100:
        print("입력 개수가 올바르지 않습니다.")
        return False
    
    if len(data) != n:
        print("입력 개수가 올바르지 않습니다.")
        return False
    
    for i in data:    
        if i.isdigit() == False:
            print("올바르지 않은 값을 입력하였습니다.")
            return False
        i = int(i)
        if i < -100 or i > 100:
            print("값의 범위가 올바르지 않습니다.")
            return False
    
    return True

def checkIfVIsCorrect(v):
    if v.isdigit() == False:
        print("올바르지 않은 값을 입력하였습니다.")
        return False
    v = int(v)
    if v < -100 or v > 100:
        print("값의 범위가 올바르지 않습니다.")
        return False
    
    return True

# 원하는 값의 개수를 출력
def printNumCnt():
    n = input()
    
    if checkIfNIsCorrect(n) == False:
        return
    
    data =  sys.stdin.readline().strip().split()
    if checkIfDataIsCorrect(data, int(n)) == False:
        return
    v = input()
    
    if checkIfVIsCorrect(v) == False:
        return
        
    print(v.count(numToCheck))
        
# Main
printNumCnt()