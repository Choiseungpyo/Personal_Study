n = int(input())
for i in range(1, 2*n):
    starNum = n - abs(n-i)
    if starNum == 0:
        starNum = n
        
    for a in range(starNum):
        print('*', end='')
    
    for b in range(2*n - 2*starNum):
        print(' ', end='')
        
    for a in range(starNum):
        print('*', end='')
    print()