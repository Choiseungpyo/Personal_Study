N = int(input())
cnt = 0
for i in range(1, N):
    n = i
    while n:
        n = i % 10
        n /= 10
    
    if n == 3 or n == 6 or n==9:
        cnt += 1 