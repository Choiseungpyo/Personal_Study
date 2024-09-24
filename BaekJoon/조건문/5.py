# 입력값이 올바른지 확인
def checkIfInputIsCorrect(value, n):
    if value.isdigit() == False:
        return False
    value = int(value)
    if value < 0 or value > n:
        return False
    return True

# 알람 설정
def setAlarm(h, m):
    if h == 0 and m < 45:
        h = 24
    sum = h * 60 + m
    sum -= 45
    
    h = int(sum / 60) 
    m = sum % 60
    print(h, m)
    
# Main
H, M = input().split(' ')

if checkIfInputIsCorrect(H, 23) and checkIfInputIsCorrect(M, 59):
    setAlarm(int(H),int(M))