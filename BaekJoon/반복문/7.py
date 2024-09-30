import sys

# 입력 값 확인
def checkIfInputIsCorrect(n):
    if n.isdigit() == False:
        print("입력 값이 숫자가 아닙니다.")
        return False
    
    n = int(n)
    if n < 0 or n > 10:
        print("입력 범위가 올바르지 않습니다.")
        return False

def testCase(n):
    for row in range(n):
        data = sys.stdin.readline().strip().split()
        sum = 0
        for col in range(len(data)):
            # 입력 값이 잘못되었을 경우
            if checkIfInputIsCorrect(data[col])==False:
                return 
            
            sum += int(data[col])
        print(f"Case #{row+1}: {sum}")
        
# Main
T = int(input())

testCase(int(T))