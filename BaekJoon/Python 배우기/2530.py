h, m, s = map(int, input().split())
d = int(input())
h += d//3600
d %= 3600
m += d//60
d %= 60
s += d

if s>=60:
  m += 1
  s = s % 60
if m>=60:
  h += 1
  m = m % 60
if h>=24:
  h = h % 24
  
print(h,m, s)