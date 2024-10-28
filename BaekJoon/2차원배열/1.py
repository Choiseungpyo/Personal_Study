# 행렬 입력
def getMatrix(n, m):
    matrix = []
    for row in range(n):
        rowResult = list(map(int, input().split(' ')))
        matrix.append(rowResult)
    return matrix

# 행렬 더하기
def addMatrix(a, b):
    result = []
    for row in range(len(a)):
        rowResult = []
        for col in range(len(a[row])):
            rowResult.append(a[row][col] + b[row][col])
        result.append(rowResult)
    return result

# 행렬 출력
def printMatrix(matrix):
    for row in range(len(matrix)):
        for col in range(len(matrix[row])):
            print(matrix[row][col], end=' ')
        print()

# Main 
n, m = map(int, input().split(' '))
storage = []
for i in range(2):
    storage.append(getMatrix(n, m))

result = addMatrix(storage[0], storage[1])
printMatrix(result)