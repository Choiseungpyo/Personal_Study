n = int(input())
cnt = 1 if n == 1 else 2*n
for row in range(1, cnt+1):
    if row % 2 != 0:
        starCnt = n//2
        if n % 2 != 0:
            starCnt += 1
        print("* "*starCnt)
    else:
        print(" *"*(n//2))