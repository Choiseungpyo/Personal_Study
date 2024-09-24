# 입력 값이 올바른지 확인
def checkIfInputIsCorrect(value, maxNum):
    if value.isdigit() == False:
        return False
    value = int(value)
    if value < 0 or value > maxNum:
        return False
    return True

# 오븐 종료 시간을 출력
def printOvenEndTime(hour, minute, n):
    result = hour * 60 + minute + n
    hour = int(result / 60)
    hour %= 24
    minute = result % 60
    
    print(hour, minute)

# Main
currTime = input().split(' ')
cookingTime = input()

if checkIfInputIsCorrect(currTime[0], 23) and checkIfInputIsCorrect(currTime[1], 59) and checkIfInputIsCorrect(cookingTime, 1000):
    printOvenEndTime(int(currTime[0]), int(currTime[1]), int(cookingTime))