# 성적 출력
def printGrade(value):
    result = ''
    
    if value >= 90:
        result = 'A'
    elif value >= 80:
        result = 'B'
    elif value >= 70:
        result = 'C'
    elif value >= 60:
        result = 'D'
    else:
        result = 'F'
        
    print(result)

# 입력값이 올바른지 확인
def CheckIfInputIsCorrect(value):
    if value < 0 or value > 100 :
        return False
    
    return True
    
testScore = input()
testScore = int(testScore)

if CheckIfInputIsCorrect(testScore):
    printGrade(testScore)