# 입력 값이 올바른지 확인
def checkIfInputIsCorrect(n):
    if n.isdigit()==False:
        print("숫자가 아닌 값을 입력하였습니다.")
        return False
    
    n = int(n)
    if n < 1 or n > 100:
        print("값의 범위가 올바르지 않습니다.")
        return False
    return True
    

def printSum(n):
    data = input()
    
    # 입력 범위만큼 입력을 하지 않았을 경우
    if len(data) != n:
        return
    data = int(data)
    sum = 0
    for i in range(n):
        sum += data % 10 
        data = data // 10 

    print(sum)


n = input()
if checkIfInputIsCorrect(n):
    printSum(int(n))