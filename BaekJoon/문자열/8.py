# 단어 개수 출력
def printWordCnt(s):
    cnt = 0
    for c in s:
        if c == ' ':
            continue
        if c.isalpha():
            cnt += 1
            continue
        print("잘못된 값을 입력하였습니다.")
        raise ValueError
    print(cnt)
    

# Main
s = input()
if len(s) <= 1000000:
    s = s.split()
    printWordCnt(s)