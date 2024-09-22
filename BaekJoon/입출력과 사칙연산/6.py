def calculate(operator, a, b):
    if operator =='+':
        print(a+b)
    elif operator =='-':
        print(a-b)
    elif operator =='*':
        print(a*b)
    elif operator =='/':
        print(int(a/b))
    elif operator =='%':
        print(a%b)

controlWhile = True # while문 제어 조건 변수
storage = []
while(controlWhile):
  storage = input().split() # 공백으로 a,b를 나누고 저장한다.

  if len(storage) != 2:
      print('다시 입력하세요')
      continue
  
  # a,b 가 조건을 만족하는지 확인
  for i in range(len(storage)):
    value = int(storage[i])
    if value >= 1 and value <= 10000 :
        storage[i] = value
        if i == len(storage) -1:
            controlWhile = False
    else:
        break

calculate('+', storage[0], storage[1])
calculate('-', storage[0], storage[1])
calculate('*', storage[0], storage[1])
calculate('/', storage[0], storage[1])
calculate('%', storage[0], storage[1])