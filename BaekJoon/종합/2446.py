n = int(input())
for i in range(1, 2*n):
    for b in range((n-1) - abs(n-i)):
        print(' ', end='')
        
    for a in range(abs(n-i)*2 + 1):
        print('*', end='')
        
    print()