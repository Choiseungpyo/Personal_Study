import sys 
while True:
    triangleData = list(map(int,  sys.stdin.readline().split()))
    
    if triangleData[0] == 0 and triangleData[0] == triangleData[1] == triangleData[2]:
        break
    
    triangleData.sort()
    result = 'wrong'
    if pow(triangleData[2], 2) == pow(triangleData[0], 2) + pow(triangleData[1], 2):
        result = 'right'
    print(result)