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
    flag = True
    while flag:
        data = input().split()
        
        if checkIfABIsCorrect(data) == False:
            break
        
        if data[0] == 0 and data[1] == 0:
            flag = False
            continue
        
        sum = add(data)
        print(sum)
        
        
# Main
testCase()