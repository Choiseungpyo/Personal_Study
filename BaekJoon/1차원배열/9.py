# 게임 시작
def startGame():
    cntData = list(map(int,input().split(' ')))
    basketData = [i for i in range(1, cntData[0]+1)]
    
    if len(cntData) != 2:
        return
    
    for i in cntData:
        if i < 1 or i > 100 :
            print("값의 범위가 올바르지 않습니다.")
            return
    
    # M번 바구니 순서 바꾸기
    for i in range(cntData[1]):
        indexDataToChange = list(map(int,input().split(' ')))
        
        if indexDataToChange[0] > indexDataToChange[1] or indexDataToChange[0] > cntData[0] or  indexDataToChange[0] > cntData[0] :
            print("i j의 값이 올바르지 않습니다.")
            return
        
        changeOrderOfBasket(basketData, indexDataToChange)
    
    # 결과값 출력
    for i in basketData:
        if i == basketData[-1]:
            print(i, end="")
        else:
            print(i, end=" ")

# 바구니의 순서 변경
def changeOrderOfBasket(basketData, cntData):
    tmp = []

    # 인덱스 사이의 값들 저장
    for i in range(len(basketData)):
        if i >= cntData[0]-1 and i < cntData[1]:
            tmp.append(basketData[i])
            
    # 해당 값들 역순으로 변경
    tmp.reverse()
    
    # 인덱스에 해당되지 않는 값들 삽입
    for i in range(len(basketData)):
        if i >= cntData[0]-1 and i < cntData[1]:
             continue
        tmp.insert(i, basketData[i])
    
    # 실제 원본 정보에 값 저장
    for i in range(len(basketData)):
        basketData[i] = tmp[i]

        
# Main
startGame()