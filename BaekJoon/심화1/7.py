# 그룹단어인지 확인
def isGroupWord(word):
    alreadyCheckCharStorage = []
    for c in word:
        flag = False
        for i in alreadyCheckCharStorage:
            if i == c:
                flag = True
                break
        if flag:
            continue
        if checkIfCharIsConntected(c, word) == False:
            return False
        alreadyCheckCharStorage.append(c)
    return True

# 문자가 이어져 있는지 확인
def checkIfCharIsConntected(c, word):
    cnt = word.count(c)
    indexStorage = []
    tmp = word

    # 인덱스 저장
    for i in range(cnt):
        indexStorage.append(tmp.index(c))
        tmp = tmp.replace(c, ' ', 1)

    # 이어져있는지 확인
    for i in range(cnt-1):
        if indexStorage[i+1] - indexStorage[i] != 1:
            return False
    return True

# Main   
wordCnt = int(input())
storage = [input() for _ in range(wordCnt)]
groupCnt = 0
for word in storage:
    if isGroupWord(word):
        groupCnt += 1
        
print(groupCnt)