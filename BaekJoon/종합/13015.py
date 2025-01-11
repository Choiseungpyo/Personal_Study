n = int(input())
for i in range(1, 2*n):
    if i == 1 or i == 2*n-1:
        print('*'*n + ' '*(2*n-3) + '*'*n)
        continue
    print(' '*((n-1)-abs(n-i)), end='')
    
    print('*' + ' '*(n-2), end='')

    if i==n:
        print('*', end='')
    else:
        print('*'+' '*(abs(n-i)*2-1)+'*', end='')
    print(' '*(n-2) + '*')