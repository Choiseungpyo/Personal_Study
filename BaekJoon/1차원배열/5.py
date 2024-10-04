import sys

# cntData 관련 값이 올바른지 확인
def checkIfCntDataIsCorrect(data):
    for num in data:
        if num.isdigit() == False:
            print("잘못된 값을 입력하였습니다")
            return False
    
        num = int(num)
        if num < 1 or num > 100:
            print("값의 범위가 올바르지 않습니다")
            return False
    
    return True

# GameData 관련 값 올바른지 확인
def checkIfGamedataIsCorrect(gameData, maxBasketNum):
    for num in gameData:
        if num.isdigit() == False:
            print("잘못된 값을 입력하였습니다")
            return False
    
        num = int(num)
        if num < 1 or num > maxBasketNum:
            print("값의 범위가 올바르지 않습니다")
            return False
        
    # i <= j 값을 충족시키지 못하는 경우
    if int(gameData[0]) > int(gameData[1]):
        print("i, j 값이 올바르지 않습니다")
        return False
    
    return True

# Game
def game():
    cntData = sys.stdin.readline().strip().split()
    
    if checkIfCntDataIsCorrect(cntData) == False:
        return
    
    # cntData 값 int형 변환
    for i in range(len(cntData)):
        cntData[i] = int(cntData[i])
    
    storage = []
    for i in range(cntData[0]):
        storage.append(0)
    
    for playCnt in range(cntData[1]):
        gameData = sys.stdin.readline().strip().split()
        
        # 값이 올바른지 확인
        if checkIfGamedataIsCorrect(gameData, cntData[0]) == False:
            return
        
        # gameData 값 int형 변환
        for i in range(len(gameData)):
            gameData[i] = int(gameData[i])
        
        # 바구니에 값 저장
        for i in range(gameData[0]-1, gameData[1]):
            storage[i] = gameData[2]
    
    # 바구니별 공 번호 결과 출력
    for playCnt in range(cntData[0]):
        if playCnt == cntData[0] -1:
            print(storage[playCnt])
        else:
            print(storage[playCnt], end=" ")
    
    
# Main
game()