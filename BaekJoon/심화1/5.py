storage = [i for i in input().upper()]
cntStorage = [ 0 for i in range(0, 26)]
maxCharIndex = 0
result = ''

# 개수 구하기
for i in range(len(storage)):
    for cntIndex in range(0, 26):
        if storage[i] == chr(cntIndex+65):
            cntStorage[cntIndex] += 1
            #print(chr(65+cntIndex)+ f" : {cntStorage[cntIndex]}")
            if cntStorage[cntIndex] > cntStorage[maxCharIndex]:
                maxCharIndex = cntIndex
            break

# 최대 개수 중복인지 확인
for i in range(0, 26):
    if i == maxCharIndex:
        continue
    
    if cntStorage[maxCharIndex] == cntStorage[i]:
        result  = '?'
        break
if result != '?':
    result = chr(maxCharIndex + 65) 
print(result)