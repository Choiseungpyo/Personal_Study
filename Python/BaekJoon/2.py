controlWhile = True # while문 제어 조건 변수
sum = 0

while(controlWhile):
  storage = input().split() # 공백으로 a,b를 나누고 저장한다.
  sum = 0
  # a,b 가 조건을 만족하는지 확인
  for i in range(len(storage)):
    value = int(storage[i])
    if value > 0 and value < 10 :
      sum += value
      if i == len(storage) -1:
        controlWhile = False
    else:
      break

print(sum)