import sys

# cntData 관련 값이 올바른지 확인
def checkIfCntDataIsCorrect(data):
    for num in data:
        if num < 1 or num > 100:
            print("값의 범위가 올바르지 않습니다")
            return False
    
    return True

# GameData 관련 값 올바른지 확인
def checkIfGamedataIsCorrect(gameData, maxBasketNum):
    for num in gameData:
        if num < 1 or num > maxBasketNum:
            print("값의 범위가 올바르지 않습니다")
            return False
        
    # i <= j 값을 충족시키지 못하는 경우
    if gameData[0] > gameData[1]:
        print("i, j 값이 올바르지 않습니다")
        return False
    
    return True

# Game
def game():
    cntData = list(map(int,sys.stdin.readline().strip().split()))
    
    if checkIfCntDataIsCorrect(cntData) == False:
        return

    storage = []
    # 바구에 적혀있는 번호와 똑같은 공 번호 넣기
    for i in range(cntData[0]):
        storage.append(i+1)
    
    for playCnt in range(cntData[1]):
        gameData = list(map(int,sys.stdin.readline().strip().split()))
        
        # 값이 올바른지 확인
        if checkIfGamedataIsCorrect(gameData, cntData[0]) == False:
            return

        # 2개의 바구니 공 서로 교환
        storage[gameData[0]-1], storage[gameData[1]-1] = storage[gameData[1]-1],storage[gameData[0]-1]
    
    # 바구니별 공 번호 결과 출력
    for playCnt in range(cntData[0]):
        if playCnt == cntData[0] -1:
            print(storage[playCnt])
        else:
            print(storage[playCnt], end=" ")
    
    
# Main
game()