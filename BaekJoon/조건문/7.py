# 입력 값이 올바른지 확인
def checkIfInputIsCorrect(data):
    if len(data) != 3:
        return False
    
    for i in data:
        if i.isdigit() == False:
            return False
        i = int(i)
        if i < 0 or i > 6:
            return False
        
    return True

def getGameData(data):
    gameData = {"sameDiceCnt": 1, "sameDice":0, "maxDice":0}
    diceData = {data[0]:1}
    data = [int(i) for i in data]
    
    
    diceData[data[0]] = data.count(data[0])
    for row in range(1, len(data)):
        for col in range(len(diceData)):
            if data[row] == diceData[col]:
                break
            
            if col == len(diceData) -1:
                diceData[len(diceData)-1] =  data.count(data[row])
    print(diceData)
    
    # maxDice
    for i in range(len(data)):
        if data[i] > gameData["maxDice"]:
            gameData["maxDice"] = data[i]
    
    return gameData
        
            
def getPriceMoney(gameData):
    if gameData["sameDiceCnt"] == 3:
        return 10000 + gameData["sameDice"] * 1000
    elif gameData["sameDiceCnt"] == 2:
        return 1000 + gameData["sameDice"] * 100
    else:
        return gameData["maxDice"] * 100
           


# Main
diceData = input().split(' ')

if checkIfInputIsCorrect(diceData) == True:
    gameData = getGameData(diceData)
    priceMoney = getPriceMoney(gameData)
    print(priceMoney)