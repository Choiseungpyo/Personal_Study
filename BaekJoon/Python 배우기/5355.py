# 계산
def cal(n, c):
  if c == '@':
    return n * 3
  elif c == '%':
    return n + 5
  elif c == '#':
    return n - 7
  return -1

n = int(input())
for i in range(n):
  storage = input().split()
  for storageIndex in range(1, len(storage)):
    storage[0] = float(storage[0])
    storage[0] = cal(storage[0], storage[storageIndex])
  print("{:.2f}".format(storage[0]))
  