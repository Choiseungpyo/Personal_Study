n = int(input())
for i in range(1, n+1):
    for space in range(n-i):
        print(' ', end='')
    for star in range(1):
        print('*', end='')
        
    if i==1:
        print()
        continue
    
    for space in range(2*(i-1)-1):
        print(' ', end='')
    for space in range(1):
        print('*', end='')
    print()