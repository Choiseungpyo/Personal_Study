# 입력 값이 올바른지 확인
def checkIfInputIsCorrect(n):
    if n.isalpha():
        return True
    
    if n.isdigit():
        n = int(n)
        if n < 0 or n > 10:
            print("값의 범위가 올바르지 않습니다.")
            return False
        return True
    
    return False
    
# Main
n = input()

if checkIfInputIsCorrect(n):
    print(ord(n))