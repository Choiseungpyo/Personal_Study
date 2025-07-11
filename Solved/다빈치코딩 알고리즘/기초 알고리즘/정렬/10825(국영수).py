A = int(input())
B = int(input())
C = int(input())
cnt = [0] * 10

for c in str(A*B*C):
    cnt[int(c)] += 1
    
for i in cnt:
    print(i)