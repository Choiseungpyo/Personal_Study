# testCnt 값이 올바른지 확인
def checkIfTestCntIsCorrect(t):
    if t.isdigit() == False:
        print("숫자가 아닌 값입니다.")
        return False
    t = int(t)
    if t < 1 or t > 10:
        print("값의 범위가 올바르지 않습니다.")
        return False
    return True

# 문자열 값이 올바른지 확인
def checkIfSentenceIsCorrect(s):
    if len(s) > 1000:
        print("값의 범위가 올바르지 않습니다.")
        return False
    
    if s.isalpha() == False:
        print("알파벳이 아닌 값입니다.")
        return False
    
    if s.islower():
        print("소문자입니다.")
        return False
   
    return True

# 첫번째, 마지막 글자를 출력
def printFirstLastLetter(testCnt):
    for i in range(testCnt):
        sentence = input()
        if checkIfSentenceIsCorrect(sentence) == False:
            return
        print(sentence[0]+sentence[-1])
    
# Main
testCnt = input()

if checkIfTestCntIsCorrect(testCnt):
    printFirstLastLetter(int(testCnt))