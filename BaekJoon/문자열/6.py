# 입력 값이 올바른지 확인
def checkIfInputIsCorrect(s):
    if len(s) > 100:
        print("값의 범위가 올바르지 않습니다.")
        return False
    
    if s.isalpha() == False:
        print("알파벳이 아닙니다.")
        return False
    
    if s.isupper():
        print("소문자가 아닙니다.")
        return False
    return True

# 알파벳 위치를 출력
def printAlphaPos(s):
    alphaSet = [chr(x) for x in range(97, 123)]
    for x in alphaSet:
        if s.find(x) == -1:
            print(-1, end = ' ')
            continue
        print(s.index(x), end = ' ')
        
# Main
s = input()
if checkIfInputIsCorrect(s):
    printAlphaPos(s)