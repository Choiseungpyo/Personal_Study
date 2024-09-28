class Sum:
    def __init__(self, n = 0):
        if n < 1 or n > 10000:
            print('잘못된 값을 입력하였습니다.')
        else:
            self.n = n
            
    def printSum(self):
        sum = 0
        for i in range(1, n+1):
            sum += i
        print(sum)
    
# Main
n = int(input())
data = Sum(n)
data.printSum()