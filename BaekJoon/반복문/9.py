# 입력 값이 올바른지 확인
def checkIfInputIsCorrect(n):
    if n.isdigit() == False:
        print("입력 값이 숫자가 아닙니다.")
        return False
    
    n = int(n)
    if n < 1 or n > 100:
        print("값의 범위가 올바르지 않습니다.")
        return False
    return True

# 별 출력
def printStar(lineCnt):
    for line in range(lineCnt):
        for startCnt in range(line+1):
            print("*", end = "")
        print()
        

# Main
lineCnt = input()
if checkIfInputIsCorrect(lineCnt):
    printStar(int(lineCnt))