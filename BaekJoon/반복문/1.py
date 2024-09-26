# N의 값이 올바른지 확인
def checkIfNisCorrect(n):
    if n.isdigit() == False:
        return False
    n = int(n)
    if n < 1 or n > 9 :
        return False
    return True

# 구구단
def multiplicationTable(n):
    for i in range(1, 10):
        print(n, "*", i, "=", n * i)
        
# Main
N = input()

if checkIfNisCorrect(N) == True:
    multiplicationTable(int(N))