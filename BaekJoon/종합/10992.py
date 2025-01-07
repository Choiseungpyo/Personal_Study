n = int(input())
for i in range(1, n+1):
    for space in range(n-i):
        print(' ', end='')
    if i == 1:
        print('*')
    elif i!=n:
        print('*'+' '*(2*i-3)+'*')
    else:
        print('*'*(2*i-1))