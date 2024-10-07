# 데이터 얻기
def getData(n):
    data = []
    for i in range(n):
        x = int(input())
        if x < 0 or x > 1000:
            print("값의 범위가 올바르지 않습니다.")
            return data
        data.append(x)
    return data

# 서로 다른 나머지 개수 출력
def printDifferentCnt(data, valueToDivide, maxCnt):
    # data가 최대 개수만큼 충족되지 않았을 경우
    if len(data) != maxCnt:
        return
    
    restData = []
    for i in data:
        i %= valueToDivide
        if restData.count(i) == 0:
            restData.append(i)
    print(len(restData))
    

# Main
maxCnt = 10
data = getData(maxCnt)
printDifferentCnt(data, 42, maxCnt)