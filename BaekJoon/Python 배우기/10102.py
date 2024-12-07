n = input()
data = input()
cntData = {'A' : data.count('A'), 'B' : data.count('B')}
result = "Tie"
if cntData['A'] > cntData['B']:
  result = "A"
elif cntData['A'] < cntData['B']:
  result = "B"
print(result)