controlWhile = True # while문 제어 조건 변수
result = 0
while(controlWhile):
  storage = input().split() # 공백으로 a,b를 나누고 저장한다.

  if len(storage) != 2:
      print('다시 입력하세요')
      continue
  
  # a,b 가 조건을 만족하는지 확인
  for i in range(len(storage)):
    value = int(storage[i])
    if value > 0 and value < 10 :
      if i == len(storage) -1 and len(storage) == 2:
        result = int(storage[i-1]) * int(storage[i])
        controlWhile = False
    else:
      break

print(result)