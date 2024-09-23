# 입력값이 올바른지 확인
def checkifInputIsCorrect(value):
    if value.isdigit() == False:
        return False
    
    value = int(value)
    if value < 1 or value > 4000:
        return False
    
    return True
     
# 윤년인지 확인
def checkIfInputIsLeapYear(value):
    if value % 4 == 0:
        if value % 100 != 0 or value % 400 == 0:
            return 1
    
    return 0


#main
year = input()

if checkifInputIsCorrect(year):
    result = checkIfInputIsLeapYear(int(year))
    print(result)