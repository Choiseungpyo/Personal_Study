cnt = int(input())
for i in range(cnt*2-1):
  for a in range(abs(cnt-1-i)):
    print(" ",end='')
  for b in range(((cnt-1)-abs(cnt-1-i)) * 2 + 1):
    print("*", end='')
  print()