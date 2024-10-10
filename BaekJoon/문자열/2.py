# 입력 값이 올바른지 확인
def checkIfInputIsCorrect(word):
    if len(word) > 100:
        print("입력 최대 길이를 넘어갔습니다")
        return False
    
    if word.isalpha() == False:
        print("알파벳이 아닙니다.")
        return False
    
    return True

# Main
word = input()

if checkIfInputIsCorrect(word):
    print(len(word))