import sys

# 입력 값 올바른지 확인
def checkIfInputIsCorrect(data):
    for n in data:
        if n.isdigit() == False:
            print("숫자가 아닌 값을 입력하였습니다.")
            return False
    
        n = int(n)

        if n < 1 or n > 10000:
            print("값의 범위가 올바르지 않습니다.")
            return False
    
    return True


# N보다 작은 값들 출력
def printValuesLessThanN(array, n):
    for i in range(len(array)):
        array[i] = int(array[i])
        if array[i] < n:
            if i == len(array) -1:
                print(array[i])
            else:
                print(array[i], end = " ")

    
# Main
data = input().split()
if checkIfInputIsCorrect(data):
    array =  sys.stdin.readline().strip().split()
    if checkIfInputIsCorrect(array):
        printValuesLessThanN(array, int(data[1]))