def eat(i, j, k):
    sum_i1 = hs[j-1] - hs[i-1] 
    sum_i2 = hs[k-1] - hs[i-1] - honeys[j]
    rst1 = sum_i1 + sum_i2

    sum_j1 = hs[j] - hs[i]
    sum_j2 = hs[k-1] - hs[j-1]
    rst2 = sum_j1 + sum_j2

    sum_k1 = hs[k] - hs[i] - honeys[j]
    sum_k2 = hs[k] - hs[j]
    rst3 = sum_k1 + sum_k2

    return max(rst1, rst2, rst3)

N = int(input())
honeys = [0] + list(map(int, input().split()))

hs = []
total = 0
for honey in honeys:
    total += honey
    hs.append(total)

rst = 0
for j in range(2, N):
    temp = eat(1, j, N)
    rst = max(rst, temp)
print(rst)