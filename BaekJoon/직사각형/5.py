# 최대 최소를 설정
def setMaxMin(n, lst):
    if n < lst[0]:
        lst[0] = n 
    if n > lst[1]:
        lst[1] = n       

# 사각형인지 체크    
def checkIfItIsSquare(storage):
    for i in range(len(storage)):
        # x 또는 y의 최소, 최대값이 같은 경우 
        if storage[i][0] == storage[i][1]:
            return False
    return True

# 사각형 넓이 출력
def printAreaOfSquare(storage):
    if checkIfItIsSquare(storage):
        print((abs(storage[0][1] - storage[0][0])) * (abs(storage[1][1] - storage[1][0])))
    else:
        print(0)

n = int(input())
storage = [[100000,0], [100000,0]] # x : min, max     y : min, max
for i in range(n):
    x,y = map(int, input().split())
    setMaxMin(x, storage[0])
    setMaxMin(y, storage[1])
    
printAreaOfSquare(storage) 