# 입력값이 올바른지 확인
def checkIfInputIsCorrect(value):
    if value <-1000 or value > 1000 or value == 0:
        return False
    return True

# N분면을 얻는다. 
def getTheNQuadrant(x, y):
    if x > 0 and y > 0:
        return 1
    elif x < 0 and y > 0:
        return 2
    elif x < 0 and y < 0:
        return 3
    elif x > 0 and y < 0:
        return 4

# Main
x = int(input())
y = int(input())

if checkIfInputIsCorrect(x) and checkIfInputIsCorrect(y):
    print(getTheNQuadrant(x,y))