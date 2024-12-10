s = int(input())
for i in range(1, s+1):
  result = 0
  if i % 2 == 0:
    result = (1 + i) * i // 2
    if result == s:
      print(i)
      break
    elif result > s:
      break
  else:
    result = (1 + i) * i // 2 + (i+1)//2
    if result == s:
      print(i)
      break
    elif result > s:
      break