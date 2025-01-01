n = int(input())
for i in range(n):
    for a in range(i):
        print(" ", end='')
    for b in range(n-i):
        print("*", end='')
    print()