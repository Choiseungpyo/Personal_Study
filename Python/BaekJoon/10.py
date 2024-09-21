def checkIfInputIsCorrect(storage, n):
    if len(storage) != n:
        print('잘못된 값을 입력하였습니다.')
        return False

    for i in range(len(storage)):
        value = int(storage[i])
        if value < 1 or value > 10 ** 12:
            print('잘못된 값을 입력하였습니다.')
            return False
        else:
            storage[i] = value
    return True

storage = input().split(' ')
n = 3 # 입력 개수

if checkIfInputIsCorrect(storage, n):
    result = 0
    for i in range(n):
        result += storage[i]
    print(result)