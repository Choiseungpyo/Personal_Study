import sys
n = int(input())
maxMoney = 0
for i in range(n):
  a,b,c = map(int, sys.stdin.readline().split())
  money = 0
  if a == b == c:
    money += 10000 + a * 1000
  elif a == b and a != c:
    money += 1000 + a * 100
  elif a == c and a != b:
    money += 1000 + a * 100
  elif b == c and b != a:
    money += 1000 + b * 100
  else:
    if a > b:
      if a > c:
        money = a * 100
      else:
        money = c * 100
    else:
      if b > c:
        money = b * 100
      else:
        money = c * 100
  if money > maxMoney:
    maxMoney = money
print(maxMoney)