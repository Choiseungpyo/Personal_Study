N = int(input())
arr = list(map(int, input().split()))

total = 0
sa = []
result = 0
for i in arr:
    total += i
    sa.append(total)

if total % 4 == 0:
    dp = [1, 0, 0, 0]
    quater = total // 4
    for i in range(N - 1):
        for j in range(3, 0, -1):
            if sa[i] == quater * j:
                dp[j] += dp[j - 1]  
    result = dp[3]
    
print(result)