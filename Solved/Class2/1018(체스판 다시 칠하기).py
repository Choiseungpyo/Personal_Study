from sys import stdin

def setData(data, dataLength, row, col):
    for i in range(dataLength):
        if row < data['minRow'][i] or row >= data['minRow'][i] + size:
            continue
        if col < data['minCol'][i] or col >= data['minCol'][i] + size:
            continue
        print(f"({row},{col}) : {i} 증가")
        data['cnt'][i] += 1
        

size = 8
n, m = map(int, input().split()) # y, x
board = ['']*n*m
for row in range(n):
    s = stdin.readline().rstrip()
    for col in range(m):
        board[row*size+col] = s[col]

dataLength = (n-size+1) * (m-size+1)
data = {'minRow' : [0] * dataLength, 'minCol':[0] * dataLength, 'cnt':[0] * dataLength}

for i in range(dataLength):
    data['minRow'][i] = i // (m-size+1)
    data['minCol'][i] = i % (m-size+1)


for row in range(n):
    for col in range(m):
        if (row*size+col) % 2 == 0:
            if row % 2 != 0:
                if board[row*size+col] == 'B':
                    setData(data, dataLength, row, col)
            else:
                if board[row*size+col] == 'W':
                    setData(data, dataLength, row, col)
        else:
            if row % 2 != 0:
                if board[row*size+col] == 'W':
                    setData(data, dataLength, row, col)
            else:
                if board[row*size+col] == 'B':
                    setData(data, dataLength, row, col)
        print(f"({row},{col}) : {board[row*size+col]}")
       
data['cnt'].sort()
print(data)
result = data['cnt'][0]
if size*size - result < result:
    result = size*size - result 
print(result)