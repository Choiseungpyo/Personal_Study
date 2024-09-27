# N의 값이 올바른지 확인
def checkIfTIsCorrect(n):
    if n.isdigit() == False:
        return False
    return True

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
def testCase(n):
    for i in range(n):
        ab = input().split()
        
        if checkIfABIsCorrect(ab) == False:
            break
        
        sum = add(ab)
        print(sum)
        
        
# Main
T = input()

if checkIfTIsCorrect(T) == True:
    testCase(int(T))