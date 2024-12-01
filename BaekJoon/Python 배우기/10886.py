import sys
n = int(input())
cnt = [0,0]
for i in range(n):
  num = int(sys.stdin.readline())
  if num == 0: cnt[0] +=1
  else: cnt[1] +=1
print("Junhee is cute!" if cnt[0] < cnt[1] else "Junhee is not cute!")