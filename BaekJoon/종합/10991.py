def printStar(n):
    print('*', end='')
    
    if n == 1:
        print()
        return
    
    print(' ', end='')
    printStar(n-1)

n = int(input())
for i in range(1, n+1):
    for space in range(n-i):
        print(' ', end='')
    printStar(i)
