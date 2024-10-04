import sys

# Max Num 관련 데이터 출력
def printMaxNumData(n):
    maxNum = 0
    maxNumIndex = 0
    for i in range(n):
        n = sys.stdin.readline().strip()
        if n.isdigit() == False:
            print("잘못된 값을 입력하였습니다")
            return 
        n = int(n)
        if n < 1 or n >= 100:
            print("값의 범위가 올바르지 않습니다")
            return
        if n > maxNum:
            maxNum = n
            maxNumIndex = i + 1
        
    print(maxNum)
    print(maxNumIndex)
    
# Main
printMaxNumData(9)