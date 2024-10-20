chessSet = [1,1,2,2,2,8]
chessSetCnt = list(map(int, input().split(' ')))
print(chessSetCnt)
for i in range(len(chessSet)):
  print(chessSet[i] - chessSetCnt[i], end = ' ')