from sys import stdin

def setData(data, dataLength, row, col):
    for i in range(dataLength):
        if row < data['row'][i][0] or row > data['row'][i][1]:
            continue
        if col < data['col'][i][0] or col > data['col'][i][1]:
            continue
        data['cnt'][i] += 1
        
# Main
size = 8
n, m = map(int, input().split()) # y, x
board = ['']*n*m
for row in range(n):
    s = stdin.readline().rstrip()
    for col in range(m):
        board[row*m+col] = s[col]

dataLength = (n-size+1) * (m-size+1)
data = {'row' : [(0,0)] * dataLength, 'col':[(0,0)] * dataLength, 'cnt':[0] * dataLength}

for i in range(dataLength):
    data['row'][i] = (i // (m-size+1), i // (m-size+1) + size-1)
    data['col'][i] = (i % (m-size+1), i % (m-size+1) + size-1)
    
for row in range(n):
    for col in range(m):
        if row % 2 == 0:
            if col % 2 == 0:
                if board[row*m+col] == 'W':
                    setData(data, dataLength, row, col)
            else:
                if board[row*m+col] == 'B':
                    setData(data, dataLength, row, col)
        else: 
            if col % 2 == 0:
                if board[row*m+col] == 'B':
                    setData(data, dataLength, row, col)
            else:
                if board[row*m+col] == 'W':
                    setData(data, dataLength, row, col)

data['cnt'].sort()
result = min([data['cnt'][0], data['cnt'][-1], 
          size*size - data['cnt'][0], size*size - data['cnt'][-1]])
print(result)