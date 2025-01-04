n = int(input())

for row in range(1, 2*n):
    sub = abs(n-row)
    
    for col in range(n-sub):
        print("*", end='')

    print()