class Receipt:
    def __init__(self):
        self.X = self.getInput([1000000000])
        self.N = self.getInput([100])
        self.sum = 0
    
    def getInput(self, maxNum):
        n = input().split(' ')
        
        for i in range(len(n)):
            if n[i].isdigit() == False:
                print('숫자가 아닌 값을 입력하였습니다')
                return 0
            n[i] = int(n[i])
            if n[i] < 1 or n[i] > maxNum[i]:
                print('값이 범위에 맞지 않습니다.')
                return 0
            
        if len(n) == 1:
            return n[0]
        else:
            return n

    def setNumAndPriceOfGoods(self):
        data = {}
        for i in range(self.N):
            obj = {'price': 0, 'num':0}

            tmp = self.getInput([1000000, 10])
            
            obj['price'] = int(tmp[0])
            obj['num'] = int(tmp[1])
            data[str(i)] = obj
            
            self.sum += obj['price'] * obj['num']
    
    def checkIfReceiptIsCorrect(self):
        if self.sum == self.X:
            print("Yes")
        else:
            print("No")
        
# Main
receipt = Receipt()
receipt.setNumAndPriceOfGoods()
receipt.checkIfReceiptIsCorrect()