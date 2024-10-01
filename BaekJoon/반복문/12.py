import sys

# A,B의 값이 올바른지 확인
def checkIfABIsCorrect(n):
    if len(n) != 2:
        return False
    
    for i in n:
        if i.isdigit() == False:
            return False
    
        i = int(i)
        if i <= 0 or i >= 10:
            return False
    return True

# add
def add(n):
    sum = 0
    for i in n:
        sum += int(i)
    return sum

# testCase
def testCase():
    while True:
        try : 
            data =  sys.stdin.readline().strip().split()
        
            if checkIfABIsCorrect(data) == False:
                break
            
            sum = add(data)
            print(sum)
            
        except EOFError:
            break
        
        
# Main
testCase()