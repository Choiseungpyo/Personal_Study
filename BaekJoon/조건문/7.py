# 입력 값이 올바른지 확인
def checkIfInputIsCorrect(data):
    if len(data) != 3:
        print('입력의 개수가 맞지 않습니다.')
        return False
    
    for i in data:
        if i.isdigit() == False:
            print("입력한 값이 숫자가 아닙니다.")
            return False
        i = int(i)
        if i < 0 or i > 6:
            print("입력한 값의 범위가 맞지 않습니다.")
            return False
        
    return True


def getGameData(data):
    gameData = {"sameDiceNum" : 0, "sameDiceCnt": 1}
    diceCntData = {}
    maxNum = 0
    data = [int(i) for i in data]
    
    for i in data:
        # diceCntData에 값이 이미 존재하는 경우
        if str(i) in diceCntData:
            diceCntData[str(i)] += 1
        else:
            diceCntData[str(i)] = 1
            diceCntData.keys()
    
    keys = list(diceCntData.keys())

    # 가장 많이 나온 주사위 개수를 확인
    for i in range(len(diceCntData)):
        if diceCntData[keys[i]] > maxNum:
            maxNum = diceCntData[keys[i]]
            gameData["sameDiceNum"] = int(keys[i])
            gameData["sameDiceCnt"] = diceCntData[keys[i]]
    
    # 입력한 값이 모두 서로 다르지 않을 경우
    if gameData["sameDiceCnt"] != 1:
        return gameData
    
    maxNum = 0
    # 입력한 값이 모두 서로 다를 경우
    # 서로 다른 값중에서 가장 큰 값을 찾기
    for i in range(len(data)):
        if data[i] > maxNum:
            maxNum = data[i]
            
    gameData["maxDiceNum"] = maxNum
    return gameData
     
            
def getPriceMoney(gameData):
    if gameData["sameDiceCnt"] == 3:
        return 10000 + gameData["sameDiceNum"] * 1000
    elif gameData["sameDiceCnt"] == 2:
        return 1000 + gameData["sameDiceNum"] * 100
    else:
        return gameData["maxDiceNum"] * 100
           
           
# Main
diceData = input().split(' ')

if checkIfInputIsCorrect(diceData):
    gameData = getGameData(diceData)
    priceMoney = getPriceMoney(gameData)
    print(priceMoney)