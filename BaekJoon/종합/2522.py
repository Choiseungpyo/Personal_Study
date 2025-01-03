n = int(input())

for row in range(1, 2*n+1):
    sub = abs(n-row)
    for space in range(sub):
        print(' ', end='')
        
    for col in range(n-sub):
        print("*", end='')
    print()