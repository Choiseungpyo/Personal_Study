import sys
n = int(input())
qCnt = [0,0,0,0,0]

for i in range(n):
    x, y = map(int, sys.stdin.readline().split())
    if x > 0 and y > 0:
        qCnt[0]+=1
    elif x < 0 and y > 0:
        qCnt[1]+=1
    elif x < 0 and y < 0:
        qCnt[2]+=1
    elif x > 0 and y < 0:
        qCnt[3]+=1
    else:
        qCnt[4]+=1
        
for i in range(len(qCnt)):
    if i==len(qCnt)-1:
        result = f"AXIS: {qCnt[i]}"
    else:
        result = f"Q{i+1}: {qCnt[i]}"
    print(result)