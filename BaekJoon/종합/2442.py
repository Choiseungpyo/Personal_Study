n = int(input())
for i in range(n):
    for _ in range(n-1-i):
        print(' ', end='')
    for _ in range(2*i+1):
        print('*', end='')
    print()