# n 값이 올바른지 확인
def checkIfNIsCorrect(n, maxSize):
    if n.isdigit() == False:
        print("숫자가 아닙니다.")
        return False
    
    n = int(n)
    if n < 1 or n > maxSize:
        print("값의 범위가 올바르지 않습니다.")
        return False
    return True
    
# 문자를 반복해서 출력
def printRepeatlyChar(cnt, s):
    if(checkIfNIsCorrect(cnt, 8) == False or (len(s) < 1 or len(s) > 20)):
        return
    s = [i for i in s]
    result = ''
    for c in s:
        for cntIndex in range(int(cnt)):
            result += c
    print(result)

# Main
t = input()

if checkIfNIsCorrect(t, 1000):
    for i in range(int(t)):
        cnt, s = input().split(' ')
        printRepeatlyChar(cnt, s)