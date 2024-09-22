def checkIfInputIsCorrect(storage):
    if len(storage) != 2 :
        print('입력값이 잘못 되었습니다')
        return False
    
    for i in range(len(storage)):
        storage[i] = int(storage[i])
        if storage[i] < -10000 or storage[i] > 10000:
            print(i+1,'번째 입력값이 잘못 되었습니다.')
            return False
    return True

storage = input().split(' ')

if checkIfInputIsCorrect(storage):

    if storage[0] > storage[1]:
        print('>')
    elif storage[0] < storage[1]:
        print('<')
    else:
        print('==')