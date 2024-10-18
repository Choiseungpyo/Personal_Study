storage = ["ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV"," WXYZ"]
word = [c for c in input()]
result = 0
for c in word:
    for i in range(len(storage)):
        if storage[i].find(c) != -1:
          result+= 3 + i
          break
print(result)  